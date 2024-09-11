-module(holidays).

-export([
            is_new_years_day/2,
            is_martin_luther_king_day/2,
            is_valentines_day/2,
            is_st_patricks_day/2,
            is_good_friday/2,
            is_easter/2,
            is_armed_forced_day/2,
            is_independence_day/2,
            is_presidents_day/2,
            is_veterans_day/2,
            is_memorial_day/2,
            is_columbus_day/2,
            is_halloween/2,
            is_thanksgiving/2,
            is_christmas_eve/2,
            is_christmas/2,
            is_new_years_eve/2
        ]).

-export([
            get_easter/2,
            is_nth_occurrence/2,
            is_holiday/3
        ]).

-type date_timestamp() :: {{pos_integer(), pos_integer(), pos_integer()}, {non_neg_integer(), non_neg_integer(), non_neg_integer()}}.


%% ======================
%% External Functions
%% ======================

-spec is_new_years_day(atom(), date_timestamp()) -> boolean().
is_new_years_day(us, {{_,M,D},_}) ->
    M =:= 1 andalso D =:= 1;
is_new_years_day(cn, {{_,M,D},_}) ->
    M =:= 1 andalso D =:= 1.

-spec is_martin_luther_king_day(atom(), date_timestamp()) -> boolean().
is_martin_luther_king_day(us, {{Y,M,D},_}) ->
    IsMonday = calendar:day_of_the_week(Y,M,D) =:= 1,
    M =:= 1 andalso IsMonday andalso is_nth_occurrence(D,3).

-spec is_valentines_day(atom(), date_timestamp()) -> boolean().
is_valentines_day(us, {{_,M,D},_}) ->
    M =:= 2 andalso D =:= 14.

-spec is_st_patricks_day(atom(), date_timestamp()) -> boolean().
is_st_patricks_day(us, {{_,M,D},_}) ->
    M =:= 3 andalso D =:= 17.

-spec is_good_friday(atom(), date_timestamp()) -> boolean().
is_good_friday(_, {{Y,M,D},_}) ->
    {GFYear, GFMonth, GFDay} = calendar:gregorian_days_to_date(calendar:date_to_gregorian_days(get_easter(catholic, Y)) - 2),
    GFYear =:= Y andalso GFMonth =:= M andalso GFDay =:= D.

-spec is_easter(atom(), date_timestamp()) -> boolean().
is_easter(Rite, {{Y,M,D},_}) when Rite =:= catholic; Rite =:= orthodox ->
    {EYear, EMonth, EDay} = get_easter(Rite, Y),
    EYear =:= Y andalso EMonth =:= M andalso EDay =:= D;
is_easter(Country, Date) when Country =:= us; Country =:= ca ->
    is_easter(catholic, Date);
is_easter(Country, Date) when Country =:= bg; Country =:= cy; Country =:= gr; Country =:= lb;
                              Country =:= mk; Country =:= ro; Country =:= ru; Country =:= ua ->
    is_easter(orthodox, Date);
is_easter(_, Date) ->
    is_easter(catholic, Date).

-spec is_armed_forced_day(atom(), date_timestamp()) -> boolean().
is_armed_forced_day(us, {{Y,M,D},_}) ->
    IsSaturday = calendar:day_of_the_week(Y,M,D) =:= 6,
    M =:= 5 andalso IsSaturday andalso is_nth_occurrence(D,3).

-spec is_independence_day(atom(), date_timestamp()) -> boolean().
is_independence_day(us, {{_,M,D},_}) ->
    M =:= 7 andalso D =:= 4.

-spec is_presidents_day(atom(), date_timestamp()) -> boolean().
is_presidents_day(us, {{Y,M,D},_}) ->
    IsMonday = calendar:day_of_the_week(Y,M,D) =:= 1,
    M =:= 2 andalso IsMonday andalso is_nth_occurrence(D,3).

-spec is_veterans_day(atom(), date_timestamp()) -> boolean().
is_veterans_day(us, {{_,M,D},_}) ->
    M =:= 11 andalso D =:= 11.

-spec is_memorial_day(atom(), date_timestamp()) -> boolean().
is_memorial_day(us, {{_,M,D},_}) ->
    IsLastMonday = ((31 - D) div 7) =:= 0,
    M =:= 5 andalso IsLastMonday.

-spec is_columbus_day(atom(), date_timestamp()) -> boolean().
is_columbus_day(us, {{Y,M,D},_}) ->
    IsMonday = calendar:day_of_the_week(Y,M,D) =:= 1,
    M =:= 10 andalso IsMonday andalso is_nth_occurrence(D,2).

-spec is_halloween(atom(), date_timestamp()) -> boolean().
is_halloween(us, {{_,M,D},_}) ->
    M =:= 10 andalso D =:= 31.

-spec is_thanksgiving(atom(), date_timestamp()) -> boolean().
is_thanksgiving(ca, {{Y,M,D},_}) ->
    IsMonday = calendar:day_of_the_week(Y,M,D) =:= 1,
    M =:= 10 andalso IsMonday andalso is_nth_occurrence(D,2);

is_thanksgiving(us, {{Y,M,D},_}) ->
    IsThursDay = calendar:day_of_the_week(Y,M,D) =:= 4,
    M =:= 11 andalso IsThursDay andalso is_nth_occurrence(D,4).

-spec is_christmas_eve(atom(), date_timestamp()) -> boolean().
is_christmas_eve(_, {{_,M,D},_}) ->
    M =:= 12 andalso D =:= 24.

-spec is_christmas(atom(), date_timestamp()) -> boolean().
is_christmas(_, {{_,M,D},_}) ->
    M =:= 12 andalso D =:= 25.

-spec is_new_years_eve(atom(), date_timestamp()) -> boolean().
is_new_years_eve(us, {{_,M,D},_}) ->
    M =:= 12 andalso D =:= 31.

-spec get_easter(atom(), pos_integer()) -> {pos_integer(), pos_integer(), pos_integer()}.
get_easter(catholic, Year) ->
    G = trunc(math:fmod(Year,19)),
    C = Year div 100,
    H = trunc(math:fmod(C - (C div 4) - ((8 * C + 13) div 25) + 19 * G + 15, 30)),
    I = H - (H div 28) * (1 - (H div 28) * trunc(29 / (H + 1)) * ((21 - G) div 11)),
    Day = trunc(I - math:fmod((Year + (Year div 4)) + I + 2 - C + (C div 4), 7) + 28),
    case Day of
        _ when Day > 31 ->
            {Year, 4, Day - 31};
        _ ->
            {Year, 3, Day}
    end;

get_easter(orthodox, Year) ->
    A = trunc(math:fmod(Year,4)),
    B = trunc(math:fmod(Year,7)),
    C = trunc(math:fmod(Year,19)),
    D = trunc(math:fmod((19*C)+15,30)),
    E = trunc(math:fmod((2*A)+(4*B)-D+34,7)),
    Month = (D+E+114) div 31,
    Day = trunc(math:fmod((D+E+114),31))+1,
    calendar:gregorian_days_to_date(calendar:date_to_gregorian_days({Year, Month, Day})+13).

-spec is_holiday(atom(), date_timestamp(), [fun()]) -> boolean().
is_holiday(CountryCode, Date, Holidays) ->
    lists:any(fun(Holiday) -> Holiday(CountryCode, Date) =:= true end, Holidays).


%% ======================
%% Internal Functions
%% ======================

-spec is_nth_occurrence(pos_integer(), pos_integer()) -> boolean().
is_nth_occurrence(Day, NthOccurrence) ->
    ((Day - 1) div 7) =:= (NthOccurrence - 1).
