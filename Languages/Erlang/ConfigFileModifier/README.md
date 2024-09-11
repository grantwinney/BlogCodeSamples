I spent a couple days figuring out how to read in an Erlang config file and modify it, using Erlang (specifically, an escript.. but that doesn't really matter). I couldn't find anything nice to use, so [I created my own solution](https://grantwinney.com/how-to-modify-a-config-file-in-erlang/).

There are only 4 functions:

* `read_terms`: Takes a filename and uses `file:consult` to return the contents of a file with Erlang terms in it.
* `write_terms`: Takes a filename, and uses `file:write_file` to write updated terms back out to it.
* `get_nested_terms`: Takes a list of keys, and drills down into the value returned by `read_terms`, so you can update a specific section of Erlang terms.
* `set_nested_terms`: Takes the same list of keys, the terms you updated, and the original full list of terms, and saves everything back in the proper place so you can pass it to `write_terms`.

There's a sample config file and erl module, which you can compile and call its functions, to see how it affects the config file.

If you have a problem, question, issue - _better way to do something!_ - just [let me know](https://github.com/grantwinney/erl-config-modifier/issues/new).
