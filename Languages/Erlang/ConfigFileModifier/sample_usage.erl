-module(sample_usage).
-export([add_dependency/0, add_group/0]).

-define(FILENAME, "sample.config").

add_dependency() ->
	case config_parser:read_terms(?FILENAME) of
		{ok, Config} ->
            Keys = [application_2, dependencies],
			Dependencies = config_parser:get_nested_terms(Keys, Config),
	        NewDependencies = Dependencies ++ [[{name, consumer}, {exe, "C:/Program Files/Acme/Consumer.exe"}]],
			UpdatedConfig = config_parser:set_nested_terms(Keys, NewDependencies, Config),
			config_parser:write_terms(?FILENAME, UpdatedConfig);
		{error, Message} ->
			io:format("Error: ~p~n", [Message])
	end.

add_group() ->
	case config_parser:read_terms(?FILENAME) of
		{ok, Config} ->
            Keys = [application_3, app_options, allowed_groups],
			Groups = config_parser:get_nested_terms(Keys, Config),
	        UpdatedGroups = Groups ++ [owner],
			UpdatedConfig = config_parser:set_nested_terms(Keys, UpdatedGroups, Config),
			config_parser:write_terms(?FILENAME, UpdatedConfig);
		{error, Message} ->
			io:format("Error: ~p~n", [Message])
	end.
