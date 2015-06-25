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
