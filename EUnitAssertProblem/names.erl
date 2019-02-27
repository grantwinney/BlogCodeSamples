-module(names).
-include_lib("eunit/include/eunit.hrl").

-spec split_name(string()) -> [string()].
split_name(FullName) ->
    string:split(FullName, " ", all).


%% EUNIT TESTS

% Test Function - should pass
split_name_test() ->
    ?assertEqual(["Grant", "Winney"], split_name("Grant Winney")).         % PASS

% Test Generator Function with a single Test Generator - should pass 
split_name_simple_generator_test_() ->
    ?_assertEqual(["Grant", "Winney"], split_name("Grant Winney")).        % PASS

% Test Generator Function with a set of Test Generators - should pass
split_name_complex_generator_test_() ->
    [
        ?_assertEqual(["Kenny", "Chesney"], split_name("Kenny Chesney")),  % PASS
        ?_assertEqual(["Bob", "Dilan"], split_name("Bob Dilan")),          % PASS
        ?_assertEqual([""], split_name(""))                                % PASS
    ].

% Test Function with wrong macro - should fail (doesn't)
split_name_invalid_test() ->
    ?_assertEqual(["Um", "What?"], split_name("Grant Winney")).            % PASS.. WTF?

% Test Generator Function, single Test Generator with wrong macro - should fail
% "result from generator names:split_name_simple_generator_invalid_test_/0 is not a test"
split_name_simple_generator_invalid_test_() ->
    ?assertEqual(["Grant", "Winney"], split_name("Grant Winney")).         % FAILS.. yay!

% Test Generator Function, set of Test Generators with wrong macro - should fail
%  result: first failing test is reported; any after it do not run
split_name_complex_generator_invalid_test_() ->
    [
        ?assertEqual({"Kenny", "Chesney"}, split_name("Kenny Chesney")),   % FAILS
        ?assertEqual({"B", "D"}, split_name("Bob Dilan")),                 % doesn't run
        ?assertEqual({"UmNo"}, split_name(""))                             % doesn't run
    ].
