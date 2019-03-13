-module(exceptions_in_tests).

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
    ?debugFmt("Do we start the test? (yes)", []),
    lists:sort(this_aint_no_list),
    ?debugFmt("Do we finish the test? (no way)", []),
    ?assertEqual("Hi Mr(s) Winney, it's 2019-02-16T01:06:48Z!", meck_test_app:get_full_name(unknown, "Winney")).

get_full_name_uses_no_names_when_neither_is_available() ->
    1/0,  % <- no good can come of this!
    ?assertEqual("Hey there, it's 2019-02-16T01:06:48Z!", meck_test_app:get_full_name(unknown, unknown)).

-endif.
