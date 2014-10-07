
%Ref: http://www.mathworks.com/help/matlab/ref/linsolve.html
%OR645, HW3 Problem 2

%A': get transpose
%eye(k): get identity matrix k*k
%ones(k): create all 1 matrix k*k

%Model 1
% P1 = [  0     0.45    0         0   0.45    0           0;
%             0     0       0.45     0   0          0.45    0;
%             0 0.45 0 0.45 0 0 0;
%             0 0.45 0.45 0 0 0 0;
%             0.9 0 0 0 0 0 0;
%             0.45 0 0 0 0 0 0.45;
%             9/70  9/70 9/70 9/70 9/70 9/70 9/70]
 
%Model 2
% P2 = [  0     0.45    0         0   0.45    0           0;
%             0     0       0.45     0   0          0.45    0;
%             0 0.45 0 0.45 0 0 0;
%             0 0.45 0.45 0 0 0 0;
%             0.9 0 0 0 0 0 0;
%             0.45 0 0 0 0 0 0.45;
%             0  0 0 0 0  0.9 0]        
   
%Model 3
P3 = [  0     0.45    0         0   0.45    0           0;
0     0       0.45     0   0          0.45    0;
0 0.45 0 0.45 0 0 0;
0 0.45 0.45 0 0 0 0;
0.9 0 0 0 0 0 0;
0.45 0 0 0 0 0 0.45;
0  0 0 0 0.45  0.45 0]

ExtraMatrix = 1/70*ones(7);      
P3 = ExtraMatrix +P3  
        
%original problem is to solve X = X*P2, sum(X) = 1
%we convert it to the standard form AX = B
%where A = (p2-eye)' + add one line(1s), note the last line to to model
%constraint of sum(X) = 1

%correspondingly, the last line of B is 1

%set A
A = P3  - eye(7)
A =[ A'; ones(1,7)]

%set B
B = zeros(8,1);
B(8) = 1;


%Linear solver
X = linsolve(A,B)
        