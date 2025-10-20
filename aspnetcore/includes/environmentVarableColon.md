The `:` separator doesn't work with environment variable hierarchical keys on all platforms. For example, the `:` separator isn't supported by [Bash](https://linuxhint.com/bash-environment-variables/). The double underscore, `__`, is:

* Supported by all platforms.
* Automatically replaced by a colon (`:`).
