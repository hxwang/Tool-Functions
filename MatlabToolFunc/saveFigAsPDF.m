
%Position plot at left hand corner with width 5 and height 5.
set(gcf, 'PaperPosition', [0 0 10 6.5]); 

%Set the paper to have width 5 and height 5.
set(gcf, 'PaperSize', [10 6.5]); 

%Save figure
saveas(gcf, 'yourFileName', 'pdf') 