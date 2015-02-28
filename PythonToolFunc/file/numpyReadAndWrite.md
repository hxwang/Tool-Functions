## Numpy File Operation


### Read data from file to matrix

```python
originData = numpy.loadtxt(inputFileName, delimiter=",", dtype = numpy.float64)
data = originData[:,column]
newdata = []
```

### Save data
```python
numpy.savetxt(output, newdata, fmt = '%0.5f')
```
