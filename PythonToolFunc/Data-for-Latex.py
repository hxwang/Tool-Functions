#!/usr/bin/python

import sys
import math
import random

def process(arrivalType, lengthType, L, dataTypeInput, normalized):

    #dataType refer to different evaluation target
    dataType = int(dataTypeInput)
    #simulation setting

    timeSlot = 480
    clusterNodeNum = 100
    capacity = timeSlot*clusterNodeNum

    #construct path
    localPath = 'hwang14'
    LPath =  'L_' + str(L) + '\\'
    dataPath = '.\data\\' + LPath
    print dataPath

    #define target name and target file name, not used though, could be used if want to output to file
    Target = ''
    if  dataType == 1:
        Target = 'Scheduled Job Num'
    elif dataType == 2:
        Target =  'Scheduled Workload'
    elif dataType == 3:
        Target = 'Profits'
    elif dataType == 4:
        Target = 'Used Green Energy'
    elif dataType == 5:
        Target = 'Used Brown Energy'
    elif dataType == 6:
        Target = 'Used Brown EnergyCost'
    elif dataType == 7:
        Target = 'Running Time'

    TargetFileName = ''
    if  dataType == 1:
        TargetFileName = 'ScheduledJobNum'
    elif dataType == 2:
        TargetFileName =  'ScheduledWorkload'
    elif dataType == 3:
        TargetFileName = 'Profits'
    elif dataType == 4:
        TargetFileName = 'UsedGreenEnergy'
    elif dataType == 5:
        TargetFileName = 'UsedBrownEnergy'
    elif dataType == 6:
        TargetFileName = 'UsedBrownEnergyCost'
    elif dataType == 7:
        TargetFileName = 'RunningTime'

    #schedulers = ['FirstFitScheduler', 'BestFitScheduler', 'GreenSlotScheduler', 'RandomFitScheduler', 'WeightedScheduler', 'SemiBestFitScheduler']

    #load the target column in each file into an array
    FFFileName = dataPath + 'FirstFitScheduler'+ '_' + arrivalType + '_' + lengthType + '.txt'
    #print FFFileName
    FFResult = []
    with open(FFFileName) as f:
        next(f)
        for line in f:
            items = line.split()
            item = items[int(dataType)-1]
            FFResult.append(float(item))
            #print '%10.2f' % float(items[int(dataType)-1])

	BFFileName = dataPath + 'BestFitScheduler'+ '_' + arrivalType + '_' + lengthType + '.txt'
    BFResult = []
    #print BFFileName
    with open(BFFileName) as f:
        next(f)
        for line in f:
            items = line.split()
            item = items[int(dataType)-1]
            BFResult.append(float(item))
            #print '%10.2f' % float(items[int(dataType)-1])

    GRFileName = dataPath + 'GreenSlotScheduler'+ '_' + arrivalType + '_' + lengthType + '.txt'
    GRResult = []
    #print GRFileName
    with open(GRFileName) as f:
        next(f)
        for line in f:
            items = line.split()
            item = items[int(dataType)-1]
            GRResult.append(float(item))
            #print '%10.2f' % float(items[int(dataType)-1])


    RFFileName = dataPath + 'RandomFitScheduler'+ '_' + arrivalType + '_' + lengthType + '.txt'
    RFResult = []
    #print RFFileName
    with open(RFFileName) as f:
        next(f)
        for line in f:
            items = line.split()
            item = items[int(dataType)-1]
            RFResult.append(float(item))
            #print '%10.2f' % float(items[int(dataType)-1])



    WFFileName = dataPath + 'WeightedScheduler'+ '_' + arrivalType + '_' + lengthType + '.txt'
    WFResult = []
    #print WFFileName
    with open(WFFileName) as f:
        next(f)
        for line in f:
            items = line.split()
            item = items[int(dataType)-1]
            WFResult.append(float(item))
            #print '%10.2f' % float(items[int(dataType)-1])

    AFFileName = dataPath + 'SemiBestFitScheduler'+ '_' + arrivalType + '_' + lengthType + '.txt'
    AFResult = []
    #print AFFileName
    with open(AFFileName) as f:
        next(f)
        for line in f:
            items = line.split()
            item = items[int(dataType)-1]
            AFResult.append(float(item))
           # print '%10.2f' % float(items[int(dataType)-1])

    print Target
    print TargetFileName


    #construct latex stream
    print 'Latex-table'
    print 'Workload% & FF & BF & RF & GS & WF & AF \\\\ \hline'
    for i in range(0,len(FFResult)):
        maxV = max(FFResult[i],BFResult[i], GRResult[i], RFResult[i],WFResult[i],AFResult[i] )
        if dataType == 2:
            FFResult[i] = (FFResult[i])/capacity
            BFResult[i] = (BFResult[i])/capacity
            GRResult[i] = (GRResult[i])/capacity
            RFResult[i] = (RFResult[i])/capacity
            WFResult[i] = (WFResult[i])/capacity
            AFResult[i] = (AFResult[i])/capacity
        if normalized == 'true':
            FFResult[i] =  FFResult[i]/maxV
            BFResult[i] =  BFResult[i]/maxV
            RFResult[i] =  RFResult[i]/maxV
            GRResult[i] =  GRResult[i]/maxV
            WFResult[i] =  WFResult[i]/maxV
            AFResult[i] =  AFResult[i]/maxV

        print '%10.0f &  %10.2f & %10.2f & %10.2f & %10.2f & %10.2f & %10.2f \\\\ \hline'  %( (i+1)*10, (FFResult[i]), (BFResult[i]), (RFResult[i]),(GRResult[i]), (WFResult[i]), (AFResult[i]))


if __name__ == '__main__':
	process(sys.argv[1],sys.argv[2],sys.argv[3],sys.argv[4],sys.argv[5])
	# process(sys.argv[1])