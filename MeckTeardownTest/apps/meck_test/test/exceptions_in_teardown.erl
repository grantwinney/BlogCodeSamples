-module(exceptions_in_teardown).

-ifdef(EUNIT).

-include_lib("eunit/include/eunit.hrl").

-import(meck_test_app, [get_full_name/2]).

setup_meck() ->
    Modules = [iso8601],
    meck:new(Modules),
    meck:expect(iso8601, format, fun(_) -> <<"2019-02-16T01:06:48Z">> end),
    Modules.

teardown_meck(Modules) ->
    ?debugFmt("Do we ALWAYS get into teardown? (yes)", []),
    1/0,
    ?debugFmt("Do we always finish the teardown? (not necessarily...)", []),
    meck:unload(Modules).

meck_test_() ->
    {foreach, fun setup_meck/0, fun teardown_meck/1,
     [
      {"pauses both names when available", fun get_full_name_uses_both_names_when_available/0},
      {"uses first name only, when last name unavailable", fun get_full_name_uses_first_name_only_when_last_name_unavailable/0},
      {"uses last name only, when first name unavailable", fun get_full_name_uses_last_name_only_when_first_name_unavailable/0},
      {"uses no names when neither is available", fun get_full_name_uses_no_names_when_neither_is_available/0}
     ]
    }.

get_full_name_uses_both_names_when_available() ->
    ?assertEqual("Hi Grant Winney, it's 2019-02-16T01:06:48Z!", meck_test_app:get_full_name("Grant", "Winney")).

get_full_name_uses_first_name_only_when_last_name_unavailable() ->
    ?assertEqual("Hi Grant, it's 2019-02-16T01:06:48Z!", meck_test_app:get_full_name("Grant", unknown)).

get_full_name_uses_last_name_only_when_first_name_unavailable() ->
    ?assertEqual("Hi Mr(s) Winney, it's 2019-02-16T01:06:48Z!", meck_test_app:get_full_name(unknown, "Winney")).

get_full_name_uses_no_names_when_neither_is_available() ->
    ?assertEqual("Hey there, it's 2019-02-16T01:06:48Z!", meck_test_app:get_full_name(unknown, unknown)).

-endif.
