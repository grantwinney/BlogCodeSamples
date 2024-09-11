-module(holidays_tests).

-include_lib("eunit/include/eunit.hrl").

is_new_years_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_new_years_day(us, get_date(2018,1,1))),
        ?_assertEqual(false, holidays:is_new_years_day(us, get_date(2018,1,2))),
        ?_assertEqual(false, holidays:is_new_years_day(us, get_date(2018,2,1)))
    ].

is_martin_luther_king_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_martin_luther_king_day(us, get_date(2018,1,15))),
        ?_assertEqual(true, holidays:is_martin_luther_king_day(us, get_date(2019,1,21))),
        ?_assertEqual(false, holidays:is_martin_luther_king_day(us, get_date(2018,1,1)))
    ].

is_valentines_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_valentines_day(us, get_date(2018,2,14))),
        ?_assertEqual(false, holidays:is_valentines_day(us, get_date(2018,2,20))),
        ?_assertEqual(true, holidays:is_valentines_day(us, get_date(2021,2,14))),
        ?_assertEqual(false, holidays:is_valentines_day(us, get_date(2018,4,14)))
    ].

is_st_patricks_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_st_patricks_day(us, get_date(2018,3,17))),
        ?_assertEqual(true, holidays:is_st_patricks_day(us, get_date(2020,3,17))),
        ?_assertEqual(false, holidays:is_st_patricks_day(us, get_date(2018,3,14)))
    ].

is_good_friday_test_() ->
    [
        ?_assertEqual(true, holidays:is_good_friday(any, get_date(2019,4,19))),
        ?_assertEqual(true, holidays:is_good_friday(any, get_date(2023,4,7))),
        ?_assertEqual(true, holidays:is_good_friday(any, get_date(2027,3,26))),
        ?_assertEqual(false, holidays:is_good_friday(any, get_date(2030,12,25)))
    ].

is_catholic_easter_test_() ->
    [
        ?_assertEqual(true, holidays:is_easter(catholic, get_date(1981,4,19))),
        ?_assertEqual(true, holidays:is_easter(catholic, get_date(2020,4,12))),
        ?_assertEqual(false, holidays:is_easter(catholic, get_date(2020,5,12))),
        ?_assertEqual(true, holidays:is_easter(catholic, get_date(2023,4,9))),
        ?_assertEqual(false, holidays:is_easter(catholic, get_date(2023,4,12))),
        ?_assertEqual(true, holidays:is_easter(catholic, get_date(2024,3,31))),
        ?_assertEqual(false, holidays:is_easter(catholic, get_date(2024,6,31))),
        ?_assertEqual(true, holidays:is_easter(catholic, get_date(2026,4,5))),
        ?_assertEqual(false, holidays:is_easter(catholic, get_date(2026,12,5))),
        ?_assertEqual(true, holidays:is_easter(catholic, get_date(2029,4,1))),
        ?_assertEqual(false, holidays:is_easter(catholic, get_date(2029,10,1)))
    ].

is_orthodox_easter_test_() ->
    [
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2010,4,4))),
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2011,4,24))),
        ?_assertEqual(false, holidays:is_easter(orthodox, get_date(2013,12,13))),
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2015,4,12))),
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2016,5,1))),
        ?_assertEqual(false, holidays:is_easter(orthodox, get_date(2017,2,2))),
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2017,4,16))),
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2018,4,8))),
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2019,4,28))),
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2020,4,19))),
        ?_assertEqual(false, holidays:is_easter(orthodox, get_date(2026,12,5))),
        ?_assertEqual(false, holidays:is_easter(orthodox, get_date(2027,10,1))),
        ?_assertEqual(true, holidays:is_easter(orthodox, get_date(2028,4,16)))
    ].

is_armed_forced_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_armed_forced_day(us, get_date(2018,5,19))),
        ?_assertEqual(true, holidays:is_armed_forced_day(us, get_date(2019,5,18))),
        ?_assertEqual(false, holidays:is_armed_forced_day(us, get_date(2018,1,1)))
    ].

is_independence_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_independence_day(us, get_date(2018,7,4))),
        ?_assertEqual(false, holidays:is_independence_day(us, get_date(2018,7,5)))
    ].

is_presidents_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_presidents_day(us, get_date(2018,2,19))),
        ?_assertEqual(true, holidays:is_presidents_day(us, get_date(2019,2,18))),
        ?_assertEqual(false, holidays:is_presidents_day(us, get_date(2018,7,5))),
        ?_assertEqual(false, holidays:is_presidents_day(us, get_date(2019,2,28)))
    ].

is_veterans_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_veterans_day(us, get_date(2018,11,11))),
        ?_assertEqual(true, holidays:is_veterans_day(us, get_date(2019,11,11))),
        ?_assertEqual(false, holidays:is_veterans_day(us, get_date(2018,1,1))),
        ?_assertEqual(false, holidays:is_veterans_day(us, get_date(2019,12,25)))
    ].

is_memorial_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_memorial_day(us, get_date(2018,5,28))),
        ?_assertEqual(true, holidays:is_memorial_day(us, get_date(2019,5,27))),
        ?_assertEqual(false, holidays:is_memorial_day(us, get_date(2018,1,1))),
        ?_assertEqual(false, holidays:is_memorial_day(us, get_date(2019,12,31)))
    ].

is_halloween_test_() ->
    [
        ?_assertEqual(true, holidays:is_halloween(us, get_date(2018,10,31))),
        ?_assertEqual(false, holidays:is_halloween(us, get_date(2018,11,1)))
    ].

is_columbus_day_test_() ->
    [
        ?_assertEqual(true, holidays:is_columbus_day(us, get_date(2018,10,8))),
        ?_assertEqual(true, holidays:is_columbus_day(us, get_date(2019,10,14))),
        ?_assertEqual(false, holidays:is_columbus_day(us, get_date(2019,1,1)))
    ].

is_thanksgiving_test_() ->
    [
        ?_assertEqual(true, holidays:is_thanksgiving(ca, get_date(2018,10,8))),
        ?_assertEqual(true, holidays:is_thanksgiving(ca, get_date(2019,10,14))),
        ?_assertEqual(false, holidays:is_thanksgiving(ca, get_date(2018,10,31))),
        ?_assertEqual(true, holidays:is_thanksgiving(us, get_date(2018,11,22))),
        ?_assertEqual(true, holidays:is_thanksgiving(us, get_date(2019,11,28))),
        ?_assertEqual(false, holidays:is_thanksgiving(us, get_date(2018,11,25)))
    ].

is_christmas_eve_test_() ->
    [
        ?_assertEqual(true, holidays:is_christmas_eve(any, get_date(2018,12,24))),
        ?_assertEqual(false, holidays:is_christmas_eve(any, get_date(2018,12,31)))
    ].

is_christmas_test_() ->
    [
        ?_assertEqual(true, holidays:is_christmas(any, get_date(2018,12,25))),
        ?_assertEqual(false, holidays:is_christmas(any, get_date(2018,12,31)))
    ].

is_new_years_eve_test_() ->
    [
        ?_assertEqual(true, holidays:is_new_years_eve(us, get_date(2018,12,31))),
        ?_assertEqual(false, holidays:is_new_years_eve(us, get_date(2019,1,1)))
    ].

get_easter_test_() ->
    [
        ?_assertEqual({2019,4,21}, holidays:get_easter(catholic, 2019)),
        ?_assertEqual({2020,4,12}, holidays:get_easter(catholic, 2020)),
        ?_assertEqual({2021,4,4}, holidays:get_easter(catholic, 2021)),
        ?_assertEqual({2022,4,17}, holidays:get_easter(catholic, 2022)),
        ?_assertEqual({2023,4,9}, holidays:get_easter(catholic, 2023)),
        ?_assertEqual({2024,3,31}, holidays:get_easter(catholic, 2024)),
        ?_assertEqual({2025,4,20}, holidays:get_easter(catholic, 2025)),
        ?_assertEqual({2026,4,5}, holidays:get_easter(catholic, 2026)),
        ?_assertEqual({2027,3,28}, holidays:get_easter(catholic, 2027)),
        ?_assertEqual({2028,4,16}, holidays:get_easter(catholic, 2028)),
        ?_assertEqual({2029,4,1}, holidays:get_easter(catholic, 2029)),
        ?_assertEqual({2030,4,21}, holidays:get_easter(catholic, 2030))
    ].

is_business_holiday_test_() ->
    [
        ?_assertEqual(true, holidays:is_holiday(us, get_date(2019,4,21), [fun holidays:is_easter/2])),
        ?_assertEqual(true, holidays:is_holiday(us, get_date(2019,12,25), [fun holidays:is_easter/2, fun holidays:is_christmas/2])),
        ?_assertEqual(false, holidays:is_holiday(us, get_date(2019,12,26), [fun holidays:is_easter/2, fun holidays:is_christmas/2])),
        ?_assertEqual(false, holidays:is_holiday(us, get_date(2019,12,25), [fun holidays:is_easter/2, fun holidays:is_christmas_eve/2]))
    ].


%% ========================
%% Test Helper Functions
%% ========================

get_date(Y,M,D) ->
    {{Y,M,D},{0,0,0}}.
