## Numpy File Operation


### Read data from file to matrix

```python
originData = numpy.loadtxt(inputFileName, delimiter=",", dtype = numpy.float64)
#column: the target column wanted
data = originData[:,column]
```

### Save data
```python
numpy.savetxt(output, newdata, fmt = '%0.5f')
```
