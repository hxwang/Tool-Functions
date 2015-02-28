## Traverse Repository


### Traverse repo to get file names
```python
import sys
import os
for f in os.listdir(inputDir):
	if f.endswith(".csv"):
		# do sth
```
