-module(exceptions_in_teardown).

-ifdef(EUNIT).

-include_lib("eunit/include/eunit.hrl").

-import(salutations_app, [greeting_time/1]).

setup() ->
    Modules = [iso8601],
    meck:new(Modules),
    meck:expect(iso8601, format, fun(_) -> <<"2019-02-16T01:06:48Z">> end),
    Modules.

teardown(Modules) ->
    ?debugFmt("Do we ALWAYS get into teardown? (yes)", []),
    1/0,
    ?debugFmt("Do we always finish the teardown? (not necessarily...)", []),
    meck:unload(Modules).

greeting_time_test_() ->
    {foreach, fun setup/0, fun teardown/1,
     [
      {fun tim_gets_expected_greeting/0},
      {fun bob_gets_expected_greeting/0},
      {fun sue_gets_expected_greeting/0}
     ]
    }.

bob_gets_expected_greeting() ->
    ?assertEqual("Hi Bob, it's 2019-02-16T01:06:48Z!", salutations_app:greeting_time("Bob")).

tim_gets_expected_greeting() ->
    ?assertEqual("Hi Tim, it's 2019-02-16T01:06:48Z!", salutations_app:greeting_time("Tim")).

sue_gets_expected_greeting() ->
    ?assertEqual("Hi Sue, it's 2019-02-16T01:06:48Z!", salutations_app:greeting_time("Sue")).

-endif.
