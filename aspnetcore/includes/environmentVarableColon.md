The `:` separator doesn't work with environment variable hierarchical keys on all platforms. `__`, the double underscore, is:

* Supported by all platforms. For example, the `:` separator is not supported by [Bash](https://linuxhint.com/bash-environment-variables/), but `__` is.
* Automatically replaced by a `:`