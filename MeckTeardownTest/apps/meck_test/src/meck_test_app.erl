%%%-------------------------------------------------------------------
%% @doc meck_test public API
%% @end
%%%-------------------------------------------------------------------

-module(meck_test_app).

-behaviour(application).

%% Application callbacks
-export([start/2, stop/1, get_full_name/2]).

%%====================================================================
%% API
%%====================================================================

start(_StartType, _StartArgs) ->
    meck_test_sup:start_link().

%%--------------------------------------------------------------------
stop(_State) ->
    ok.

%% EXTERNAL

get_full_name(unknown, unknown) ->
    "Hey there, it's " ++ current_time() ++ "!";
get_full_name(FirstName, unknown) ->
    "Hi " ++ FirstName ++ ", it's " ++ current_time() ++ "!";
get_full_name(unknown, LastName) ->
    "Hi Mr(s) " ++ LastName ++ ", it's " ++ current_time() ++ "!";
get_full_name(FirstName, LastName) ->
    "Hi " ++ FirstName ++ " " ++ LastName ++ ", it's " ++ current_time() ++ "!".

%% INTERNAL

current_time() ->
    binary_to_list(iso8601:format(calendar:universal_time())).
