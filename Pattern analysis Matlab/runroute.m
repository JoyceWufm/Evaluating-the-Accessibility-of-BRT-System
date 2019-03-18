%Stopruntime_route_80022_time_other_3_4
%Stopruntime_route_80020_time_other_3_4
%Stopruntime_route_80050_time_other_3_4
%Stopruntime_route_80010_time_other_3_4
%Stopruntime_route_80090_time_other_3_4
%Stopruntime_route_80060_time_other_3_4

%Stopruntime_route_80210_time_other_3_4
%Stopruntime_route_80120_time_other_3_4
%Stopruntime_route_80200_time_other_3_4
%Stopruntime_route_80270_time_other_3_4



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%文件读取
name1 = 'stopruntime_route_80010_time_other_3_4.txt';
fid1=fopen(name1,'r');%文件名string怎么赋值？
a1=textscan(fid1,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b1=a1{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table1=tabulate(b1(:));
%获取峰值
k=0;
s=0;
r=0;
maxt1=max(table1(:,3));
maxtime1=max(table1(:,1));
for t=1:maxtime1
    if table1(t,3) == maxt1
        break;
    end
end
ximaxf1=table1(t,1);

%峰值前半段判断
for j=1:t
    p=table1(j,3);
    if p < maxt1
        if p > 0
            s=s+1;
            if s > 5
            break;
            end  
        elseif p == 0 && s>=0
            s=s-1;
        end
        continue;
    end
end
j=j-s;

%峰值后半段无效数据的排除
for i=t:maxtime1
    q=table1(i,3);
    if q < 0.02
        k=k+1;
        if k>5
        break;
        end
    elseif p > 0 && k>0
        k=k-1;
    end
end
i=i-k;

%对数据重新整理，去除错误的数据
newtable1=table1(j:i,:);
maxst1=max(newtable1(:,1));
minst1=min(newtable1(:,1));
sortb1=sort(b1);
sizeb1=size(b1);
for ti=1:sizeb1(1)
    if sortb1(ti) == minst1
        sortb1(1:ti) = [];
        break;
    end
end
for tii=1:sizeb1(1)-ti
    if sortb1(tii)-maxst1 > 5
        sortb1(tii:sizeb1(1)-ti) = [];
        break;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%重新用有效数据计算
[f1,xi1]=ksdensity(sortb1);

% sb1=size(sortb1);
% f1=f1*sb1(1);
maxf1=max(f1);
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta1=var(sortb1);%方差
Mean1=mean(sortb1);%均值

[mu1,sigma1]=normfit(sortb1);
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%文件读取
name2 = 'stopruntime_route_80020_time_other_3_4.txt';
fid2=fopen(name2,'r');%文件名string怎么赋值？
a2=textscan(fid2,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b2=a2{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table2=tabulate(b2(:));
%获取峰值
k=0;
s=0;
r=0;
maxt2=max(table2(:,3));
maxtime2=max(table2(:,1));
for t=1:maxtime2
    if table2(t,3) == maxt2
        break;
    end
end
ximaxf2=table2(t,1);
%峰值前半段判断
for j=1:t
    p=table2(j,3);
    if p < maxt2
        if p > 0
            s=s+1;
            if s > 5
            break;
            end  
        elseif p == 0 && s>=0
            s=s-1;
        end
        continue;
    end
end
j=j-s;

%峰值后半段无效数据的排除
for i=t:maxtime2
    q=table2(i,3);
    if q < 0.02
        k=k+1;
        if k>5
        break;
        end
    elseif p > 0 && k>0
        k=k-1;
    end
end
i=i-k;

%对数据重新整理，去除错误的数据
newtable2=table2(j:i,:);
maxst2=max(newtable2(:,1));
minst2=min(newtable2(:,1));
sortb2=sort(b2);
sizeb2=size(b2);
for ti=1:sizeb2(1)
    if sortb2(ti) == minst2
        sortb2(1:ti) = [];
        break;
    end
end
for tii=1:sizeb2(1)-ti
    if sortb2(tii)-maxst2 > 5
        sortb2(tii:sizeb2(1)-ti) = [];
        break;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%重新用有效数据计算
[f2,xi2]=ksdensity(sortb2);
% sb2=size(sortb2);
% f2=f2*sb2(1);
maxf2=max(f2);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta2=var(sortb2);%方差
Mean2=mean(sortb2);%均值

%正态分布拟合判断

[mu2,sigma2]=normfit(sortb2);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%文件读取
name3 = 'stopruntime_route_80030_time_other_3_4.txt';
fid3=fopen(name3,'r');%文件名string怎么赋值？
a3=textscan(fid3,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b3=a3{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table3=tabulate(b3(:));
%获取峰值
k=0;
s=0;
r=0;
maxt3=max(table3(:,3));
maxtime3=max(table3(:,1));
for t=1:maxtime3
    if table3(t,3) == maxt3
        break;
    end
end
ximaxf3=table3(t,1);
%峰值前半段判断
for j=1:t
    p=table3(j,3);
    if p < maxt3
        if p > 0
            s=s+1;
            if s > 5
            break;
            end  
        elseif p == 0 && s>=0
            s=s-1;
        end
        continue;
    end
end
j=j-s;

%峰值后半段无效数据的排除
for i=t:maxtime3
    q=table3(i,3);
    if q < 0.02
        k=k+1;
        if k>5
        break;
        end
    elseif p > 0 && k>0
        k=k-1;
    end
end
i=i-k;

%对数据重新整理，去除错误的数据
newtable3=table3(j:i,:);
maxst3=max(newtable3(:,1));
minst3=min(newtable3(:,1));
sortb3=sort(b3);
sizeb3=size(b3);
for ti=1:sizeb3(1)
    if sortb3(ti) == minst3
        sortb3(1:ti) = [];
        break;
    end
end
for tii=1:sizeb3(1)-ti
    if sortb3(tii)-maxst3 > 5
        sortb3(tii:sizeb3(1)-ti) = [];
        break;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%重新用有效数据计算
[f3,xi3]=ksdensity(sortb3);
% sb3=size(sortb3);
% f3=f3*sb3(1);
maxf3=max(f3);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta3=var(sortb3);%方差
Mean3=mean(sortb3);%均值

%正态分布拟合判断

alpha=0.05;
[mu3,sigma3]=normfit(sortb3);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%文件读取
name4 = 'stopruntime_route_80120_time_other_3_4.txt';
fid4=fopen(name4,'r');%文件名string怎么赋值？
a4=textscan(fid4,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b4=a4{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table4=tabulate(b4(:));
%获取峰值
k=0;
s=0;
r=0;
maxt4=max(table4(:,3));
maxtime4=max(table4(:,1));
for t=1:maxtime4
    if table4(t,3) == maxt4
        break;
    end
end
ximaxf4=table4(t,1);
%峰值前半段判断
for j=1:t
    p=table4(j,3);
    if p < maxt4
        if p > 0
            s=s+1;
            if s > 5
            break;
            end  
        elseif p == 0 && s>=0
            s=s-1;
        end
        continue;
    end
end
j=j-s;

%峰值后半段无效数据的排除
for i=t:maxtime4
    q=table4(i,3);
    if q < 0.02
        k=k+1;
        if k>5
        break;
        end
    elseif p > 0 && k>0
        k=k-1;
    end
end
i=i-k;

%对数据重新整理，去除错误的数据
newtable4=table4(j:i,:);
maxst4=max(newtable4(:,1));
minst4=min(newtable4(:,1));
sortb4=sort(b4);
sizeb4=size(b4);
for ti=1:sizeb4(1)
    if sortb4(ti) == minst4
        sortb4(1:ti) = [];
        break;
    end
end
for tii=1:sizeb4(1)-ti
    if sortb4(tii)-maxst4 > 5
        sortb4(tii:sizeb4(1)-ti) = [];
        break;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%重新用有效数据计算
[f4,xi4]=ksdensity(sortb4);
% sb4=size(sortb4);
% f4=f4*sb4(1);
maxf4=max(f4);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta4=var(sortb4);%方差
Mean4=mean(sortb4);%均值

%正态分布拟合判断

alpha=0.05;
[mu4,sigma4]=normfit(sortb4);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%文件读取
name5 = 'stopruntime_route_80120_time_7-9am_3_4.txt';
fid5=fopen(name5,'r');%文件名string怎么赋值？
a5=textscan(fid5,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b5=a5{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table5=tabulate(b5(:));
%获取峰值
k=0;
s=0;
r=0;
maxt5=max(table5(:,3));
maxtime5=max(table5(:,1));
for t=1:maxtime5
    if table5(t,3) == maxt5
        break;
    end
end
ximaxf5=table5(t,1);
%峰值前半段判断
for j=1:t
    p=table5(j,3);
    if p < maxt5
        if p > 0
            s=s+1;
            if s > 5
            break;
            end  
        elseif p == 0 && s>=0
            s=s-1;
        end
        continue;
    end
end
j=j-s;

%峰值后半段无效数据的排除
for i=t:maxtime5
    q=table5(i,3);
    if q < 0.02
        k=k+1;
        if k>5
        break;
        end
    elseif p > 0 && k>0
        k=k-1;
    end
end
i=i-k;

%对数据重新整理，去除错误的数据
newtable5=table5(j:i,:);
maxst5=max(newtable5(:,1));
minst5=min(newtable5(:,1));
sortb5=sort(b5);
sizeb5=size(b5);
for ti=1:sizeb5(1)
    if sortb5(ti) == minst5
        sortb5(1:ti) = [];
        break;
    end
end
for tii=1:sizeb5(1)-ti
    if sortb5(tii)-maxst5 > 5
        sortb5(tii:sizeb5(1)-ti) = [];
        break;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%重新用有效数据计算
[f5,xi5]=ksdensity(sortb5);
% sb5=size(sortb5);
% f5=f5*sb5(1);
maxf5=max(f5);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta5=var(sortb5);%方差
Mean5=mean(sortb5);%均值

%正态分布拟合判断

alpha=0.05;
[mu5,sigma5]=normfit(sortb5);


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%文件读取
name6 = 'Stopruntime_route_80120_time_5-7pm_3_4.txt';
fid6=fopen(name6,'r');%文件名string怎么赋值？
a6=textscan(fid6,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b6=a6{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table6=tabulate(b6(:));
%获取峰值
k=0;
s=0;
r=0;
maxt6=max(table6(:,3));
maxtime6=max(table6(:,1));
for t=1:maxtime6
    if table6(t,3) == maxt6
        break;
    end
end
ximaxf6=table6(t,1);
%峰值前半段判断
for j=1:t
    p=table6(j,3);
    if p < maxt6
        if p > 0
            s=s+1;
            if s > 5
            break;
            end  
        elseif p == 0 && s>=0
            s=s-1;
        end
        continue;
    end
end
j=j-s;

%峰值后半段无效数据的排除
for i=t:maxtime6
    q=table6(i,3);
    if q < 0.02
        k=k+1;
        if k>5
        break;
        end
    elseif p > 0 && k>0
        k=k-1;
    end
end
i=i-k;

%对数据重新整理，去除错误的数据
newtable6=table6(j:i,:);
maxst6=max(newtable6(:,1));
minst6=min(newtable6(:,1));
sortb6=sort(b6);
sizeb6=size(b6);
for ti=1:sizeb6(1)
    if sortb6(ti) == minst6
        sortb6(1:ti) = [];
        break;
    end
end
for tii=1:sizeb6(1)-ti
    if sortb6(tii)-maxst6 > 5
        sortb6(tii:sizeb6(1)-ti) = [];
        break;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%重新用有效数据计算
[f6,xi6]=ksdensity(sortb6);
% sb6=size(sortb6);
% f6=f6*sb6(1);
maxf6=max(f6);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta6=var(sortb6);%方差
Mean6=mean(sortb6);%均值

%正态分布拟合判断

alpha=0.05;
[mu6,sigma6]=normfit(sortb6);




%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%文件读取
name7 = 'Stopruntime_route_80120_3_4.txt';
fid7=fopen(name7,'r');%文件名string怎么赋值？
a7=textscan(fid7,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b7=a7{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table7=tabulate(b7(:));
%获取峰值
k=0;
s=0;
r=0;
maxt7=max(table7(:,3));
maxtime7=max(table7(:,1));
for t=1:maxtime7
    if table7(t,3) == maxt7
        break;
    end
end
ximaxf7=table7(t,1);
%峰值前半段判断
for j=1:t
    p=table7(j,3);
    if p < maxt7
        if p > 0
            s=s+1;
            if s > 5
            break;
            end  
        elseif p == 0 && s>=0
            s=s-1;
        end
        continue;
    end
end
j=j-s;

%峰值后半段无效数据的排除
for i=t:maxtime7
    q=table7(i,3);
    if q < 0.02
        k=k+1;
        if k>5
        break;
        end
    elseif p > 0 && k>0
        k=k-1;
    end
end
i=i-k;

%对数据重新整理，去除错误的数据
newtable7=table7(j:i,:);
maxst7=max(newtable7(:,1));
minst7=min(newtable7(:,1));
sortb7=sort(b7);
sizeb7=size(b7);
for ti=1:sizeb7(1)
    if sortb7(ti) == minst7
        sortb7(1:ti) = [];
        break;
    end
end
for tii=1:sizeb7(1)-ti
    if sortb7(tii)-maxst7 > 5
        sortb7(tii:sizeb7(1)-ti) = [];
        break;
    end
end

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%重新用有效数据计算
[f7,xi7]=ksdensity(sortb7);
% sb7=size(sortb7);
% f7=f7*sb7(1)/10;
maxf7=max(f7);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta7=var(sortb7);%方差
Mean7=mean(sortb7);%均值

%正态分布拟合判断

alpha=0.05;
[mu7,sigma7]=normfit(sortb7);






%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



figure(1);
%绘图
c1=[maxf1 maxf2 maxf3 maxf4 maxf5 maxf6 maxf7];
c2=[minst1 minst2 minst3 minst4 minst5 minst6 minst7];
c3=[maxst1 maxst2 maxst3 maxst4 maxst5 maxst6 maxst7];
% c1=[maxf1 maxf2 maxf3 maxf7];
% c2=[minst1 minst2 minst3 minst7];
% c3=[maxst1 maxst2 maxst3 maxst7];
maxfn=max(c1);
minst=min(c2);
maxst=max(c3);
% xi=[xi1,xi2,xi3,xi4,xi5,xi6];
% f=[f1,f2,f3,f4,f5,f6];
%ksdensity
plot(xi7,f7,'k','LineWidth',2.5)
hold on;
plot(xi1,f1,'g','LineWidth',2);
hold on;
plot(xi2,f2,'b','LineWidth',2)
hold on;
plot(xi3,f3,'r','LineWidth',2)
hold on;
plot(xi4,f4,'m','LineWidth',2)
hold on;
plot(xi5,f5,'c','LineWidth',2)
hold on;
plot(xi6,f6,'y','LineWidth',2)
hold on;


axis([minst-10,maxst+10,0,maxfn*1.2]);
box off
title('Stopruntime route 80022 stop 3-4');
xlabel('time(s)')
ylabel('F-出现的次数')
legend('\fontsize{8}\it all route','\fontsize{8}\it 80010','\fontsize{8}\it 80020','\fontsize{8}\it 80030','\fontsize{8}\it 80120','\fontsize{8}\it 80160','\fontsize{8}\it 80200');
