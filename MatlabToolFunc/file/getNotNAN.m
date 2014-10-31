%get non-NAN data in an array
%e.g. y is the array
    
y(~isnan(y(:,5)),5)