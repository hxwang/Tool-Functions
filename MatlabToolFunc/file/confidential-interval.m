
A = [3.00 2.87 3.58 3.28 3.87 4.14 5.23 3.86 2.88 4.37 4.75 4.33 3.17 2.85 4.16 4.03 3.57 3.68 3.95 3.58];

meanV = mean(A)

varV = var(A)

%90 confidence interval
alpha = 0.1 

sizeA = size(A,2)

t = tinv(1-alpha/2,sizeA)

delta = t*sqrt(varV)/sqrt(sizeA)
lower = meanV - delta
upper = meanV + delta
