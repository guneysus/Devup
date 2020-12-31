# Devup

## Installation

The idea @ybrs's project-switcher, reimplemented with .NET.

```shell
scoop install https://raw.githubusercontent.com/guneysus/devup/master/devup.json
```

## Usage

devup, expects a yaml file on your `$HOME` directory:

```
$HOME\.devup.yml
```

YAML definition is simple, needs only three parameters:

- Target name
- Working Directory
- Command

```yml
redis:
  pwd: D:\myrepos\docker\redis
  cmd: .\run.ps1
sync-repos:
  pwd: D:\myrepos
  cmd: ls -Directory | %{ echo $_.FullName ("=" * $_.FullName.length); git -C $_ pull -q }
```

All commands executed by Powershell and run independent.

The syntax may be improved by supporting:

- Running commands sequentially,
- Stopping the execution if one of commands fails,
- Defining sub targets that executes after a target succeeded

etc.


## Contributing

- Throw an 💡
- Or PR 🚜

