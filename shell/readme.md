## Shell command

### Run a job periodically
```
#!/bin/sh
while true
do
    sh special_svn_script.sh
    sleep 10
done
```

### Run a job in background
- use `screen` to open a new terminal
- use `ctrl a d` to detach
