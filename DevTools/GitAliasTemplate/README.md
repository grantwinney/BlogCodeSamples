Git's "alias" feature provides a way for you to create shortcuts for other Git commands, which can save you a lot of time in the long run. If you want to learn more, [I wrote a bit about it here](https://grantwinney.com/what-is-a-git-alias-and-how-do-i-use-it/).

The `*.gitconfig` files in this repo are a collection of some useful aliases I created, some for long git commands or chains of commands, and others for common typos.

If you'd like to use them, you don't have to copy/paste anything. Instead, clone the repository and reference it from within your existing `.gitconfig` file, which has the added benefit of leaving your existing aliases and other settings untouched. Add the following section to your `.gitconfig` file, where `/your/path` is wherever you cloned the repo to.

```
[include]
    path = "/your/path/git-alias-template/alias-shortcuts.gitconfig"
    path = "/your/path/git-alias-template/alias-typos.gitconfig"
    # etc...
```

The `include` section imports settings from other files and merges their functionality without affecting the original config file.

You can read more about Git aliases here:

* [GitHowTo: Aliases](https://githowto.com/aliases)
* [Pro Git: 2.7 Git Basics – Git Aliases](https://git-scm.com/book/en/v2/Git-Basics-Git-Aliases)

Do you have any especially useful aliases of your own that you couldn't live without? If you want to share them, feel free to [create a pull request](https://help.github.com/articles/creating-a-pull-request/) and I'll check them out.
