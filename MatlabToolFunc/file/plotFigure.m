%Build Figure
figure1 = figure;
set(figure1,'units','normalized','outerposition',[0 0 1 1]);

axes1 = axes('Parent',figure1);
box(axes1,'on');
hold(axes1,'all');
set(axes1,'FontSize',30,'FontWeight','bold');


%set x,y axis
x=[1:10]
y=[1:2:20]

%plot and set font, line type
p = plot(x(1,:),y(1,:));
set(p, 'Color', 'g', 'LineWidth', 3, 'linestyle','--');
set(p, 'Marker', '<', 'MarkerSize', 10);
    
    
    
  
%set x range and y range
axis([0 10 0 20])  

%set x tick and y tick
%set(axes1,'YTick',[0.2,0.4,0.6,0.8,1.0],'YTickLabel',{'20%','40%','60%','80%','100%'},'XGrid','on','YGrid','on');
%set(axes1,'XTick',[200,400,600,800,1000],'XTickLabel',{200,400,600,800,1000},'XGrid','on','YGrid','on');
 
%set grid on 
set(axes1,'XGrid','on','YGrid','on');
    
%set legend
legend(axes1,'show','Location','NorthWest','FontSize',10,'FontWeight','bold');
legend('sample');

%set x, y Label
set(get(axes1,'XLabel'),'String','x','FontSize',30,'FontWeight','bold');
set(get(axes1,'YLabel'),'String','y','FontSize',30,'FontWeight','bold');

%save to file
set(gcf, 'PaperPosition', [0 0 13 7]); %Position plot at left hand corner with width 5 and height 5.
set(gcf, 'PaperSize', [13 7]); %Set the paper to have width 5 and height 5.
%saveas(gcf, 'SolarTrace_High', 'pdf') %Save figure
saveas(gcf, '.\figures\HomeUsageTrace', 'pdf') %Save figure  
saveas(gca, strcat('.\figures\HomeUsageTrace', '.eps'),'psc2') %Save figure 

%set title
%title('10000 Attackers, 1000 Proxies');
 
