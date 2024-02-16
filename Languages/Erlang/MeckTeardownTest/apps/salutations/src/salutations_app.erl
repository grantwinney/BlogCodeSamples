%%%-------------------------------------------------------------------
%% @doc salutations public API
%% @end
%%%-------------------------------------------------------------------

-module(salutations_app).

-behaviour(application).

%% Application callbacks
-export([start/2, stop/1, greeting_time/1]).

%%====================================================================
%% API
%%====================================================================

start(_StartType, _StartArgs) ->
    salutations_sup:start_link().

%%--------------------------------------------------------------------
stop(_State) ->
    ok.

%% EXTERNAL

greeting_time(Name) ->
    format("Hi ~s, it's ~s!", [Name, current_time()]).

%% INTERNAL

current_time() ->
    binary_to_list(iso8601:format(calendar:universal_time())).

format(Template, Params) ->
    lists:flatten(io_lib:fwrite(Template, Params)).