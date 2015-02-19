
%usage
%objective:  minimize fx
%subject to: Ax <= B

f = [0; 0; 0; -1];
A = [1 1 0 1 
    1 0 1 1 
    0 1 1 1
    1 1 1 1
    -1 -1 -1 0 
    1 1 1 0];

b = [0; 0; 100; 200; -200; 200];

[x, fval] = linprog(f, A, b)
