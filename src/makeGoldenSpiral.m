function makeGoldenSpiral
  function [y,b] = arc(x,r,th)
    y = [r * cos(th) + x(1); r * sin(th) + x(2)];
    b = [min(y,[],2), max(y,[],2)];
  end
  
  function plotArc(y,b)
    if ~isempty(b)
      plot([b(1,1),b(1,1),b(1,2),b(1,2),b(1,1)],[b(2,1),b(2,2),b(2,2),b(2,1),b(2,1)],'k','linewidth',2);
    end
    hold on;
    if ~isempty(y)
      plot(y(1,:),y(2,:),'k','linewidth',2);
      %      plot(y(1,end),y(2,end),'<');
    end
    hold off;
  end
  
  function goldenSpiral(n)
    fibb = [1,1];
    
    clf;
    y = [];
    b = [[-1;1],[0;2]];
    plotArc(y,b);
    dir = 0;
    endPoint = [0;1];
    for i = 1:n
      [y,b] = arc([0,0],fibb(i+1),linspace(0,-pi/2,fibb(i+1)*90));
      A = [cos(dir*pi/180), -sin(dir*pi/180); sin(dir*pi/180), cos(dir*pi/180)];
      y = A*y;
      startPoint = y(:,1);
      v = endPoint-startPoint;
      y = y+v*ones(1,size(y,2));
      b = A*b+v*ones(1,size(b,2));
      zero = v;
      one = A*fibb(i+1)*[1;-1]+v;
      hold on
      plotArc(y,b);
      hold off
      endPoint = y(:,end);
      zero = v;
      one = A*fibb(i+1)*[1;-1]+v;
      p=.6;
      text(p*zero(1)+(1-p)*one(1),p*zero(2)+(1-p)*one(2),num2str(fibb(i+1)),'fontsize',16)
      fibb(end+1) = fibb(end-1)+fibb(end);
      dir = mod(dir-90,360);
    end
  end
  
  goldenSpiral(6);
  axis equal tight
  grid on
  ax = gca;
  xTicks = ax.XAxis.TickValues;
  yTicks = ax.YAxis.TickValues;
  ax.XAxis.TickValues = floor(min(xTicks)):ceil(max(xTicks));
  ax.YAxis.TickValues = floor(min(yTicks)):ceil(max(yTicks));
  ax.XTickLabel = cellfun(@(x) '',ax.XTickLabel,'UniformOutput', false);
  ax.YTickLabel = cellfun(@(x) '',ax.YTickLabel,'UniformOutput', false);
  export_fig('Fibonacci_spiral.pdf');
end
