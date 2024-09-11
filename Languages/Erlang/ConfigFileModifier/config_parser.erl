% Author: Grant Winney
% License: MIT

-module(config_parser).

-export([read_terms/1, get_nested_terms/2, set_nested_terms/3, write_terms/2]).

read_terms(FileName) ->
    case file:consult(FileName) of
        {ok, [Terms]} ->
            {ok, Terms};
        {error, {_Line, _Mod, _Term} = Reason} ->
            {error, file:format_error(Reason)};
        {error, Reason} ->
            {error, error_message(Reason, FileName)}
    end.

write_terms(FileName, Terms) ->
    Format = fun(Term) -> io_lib:format("~tp.~n", [Term]) end,
    file:write_file(FileName, lists:map(Format, [Terms])).

get_nested_terms(Keys, Terms) ->
    lists:foldl(fun(Key, InnerTerms) -> proplists:get_value(Key, InnerTerms) end, Terms, Keys).

set_nested_terms([Key], ReplacementTerms, Terms) ->
    lists:keyreplace(Key, 1, Terms, {Key, ReplacementTerms});
set_nested_terms([Key|NestedKeys], ReplacementTerms, Terms) ->
    InnerValue = set_nested_terms(NestedKeys, ReplacementTerms, proplists:get_value(Key, Terms)),
    lists:keyreplace(Key, 1, Terms, {Key, InnerValue}).


error_message(enoent, FileName) ->
    io_lib:format("The file does not exist: ~p", [FileName]);
error_message(eaccess, FileName) ->
    io_lib:format("Missing permission for reading the file, or for searching one of the parent directories: ~p", [FileName]);
error_message(eisdir, FileName) ->
    io_lib:format("The named file is a directory: ~p", [FileName]);
error_message(enotdir, FileName) ->
    io_lib:format("A component of the filename is not a directory: ~p", [FileName]);
error_message(enomem, _FileName) ->
    io_lib:format("There is not enough memory for the contents of the file.");
error_message(Error, FileName) ->
    io_lib:format("~p error: ~p", [Error, FileName]).
