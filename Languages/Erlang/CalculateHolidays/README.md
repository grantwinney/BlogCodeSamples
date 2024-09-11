# erl-holidays

This is a module for testing whether or not a particular date is a holiday. Right now it's pretty much only US holidays, but [contributions are welcome](CONTRIBUTING.md)!

To use it, just pass in the [2-letter country code](https://www.worldatlas.com/aatlas/ctycodes.htm) and a standard `DateTime` in `{{Y,M,D},{H,m,s}` format. The time portion of the date is never used, but I wanted it to be as easy to pass in values obtained from the likes of [`local_time_to_universal_time_dst`](http://erlang.org/doc/man/calendar.html#local_time_to_universal_time_dst-1) and [`universal_time`](http://erlang.org/doc/man/calendar.html#universal_time-0).

## Issues / Suggestions

There's a separate module with dozens of tests to validate each holiday, so hopefully everything is okay.

If you see anything that looks wrong, or have new holidays to add, either [open a new issue](https://github.com/grantwinney/erl-holidays/issues/new) with as many details as possible or [create a new PR](https://github.com/grantwinney/erl-holidays/pulls).

## Running EUnit Tests

There were plenty of [EUnit tests](erlang.org/doc/apps/eunit/chapter.html#running-eunit) to validate that the calculations are correct, especially for more complex ones like Easter. Clone the project locally and run the tests normally:

```erlang
c(holidays).
c(holidays-tests).
eunit_test(holidays_tests).
```

## Implementation Notes

If you call `holidays:is_holiday()` and pass in a country code, the path `is_easter` travels depends on which rite (if any) the country observes.

```erlang
is_business_holiday_test() ->
    ?assertEqual(true, holidays:is_holiday(us, get_date(2029,4,1), [fun holidays:is_easter/2])),
```

If your country code isn't in the `holidays` module, then add a [guard clause](http://erlang.org/doc/reference_manual/expressions.html#guard-sequences) as appropriate.

```erlang
is_easter(Country, Date) when Country =:= us; Country =:= ca ->
    is_easter(catholic, Date);
is_easter(Country, Date) when Country =:= bg; Country =:= cy; Country =:= gr; Country =:= lb;
                              Country =:= mk; Country =:= ro; Country =:= ru; Country =:= ua>
    is_easter(orthodox, Date);
is_easter(_, Date) ->            % catch-all
    is_easter(catholic, Date).
```
