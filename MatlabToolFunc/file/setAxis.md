## Axis Setting


### Set x-axis with TimeStamp
- convert time to the same scale with that in matlab
```matlab
time = (time ) / 86400 +  datenum('01-Jan-1970');
datetick('x', 'mm/dd HH:MM' ,'keepticks')
```
