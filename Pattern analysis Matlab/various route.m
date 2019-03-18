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
name1 = 'Stopruntime_route_80022_time_other_3_4.txt';
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
maxf1=max(f1);
sb1=size(sortb1);
f1=f1*sb1(1);
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta1=var(sortb1);%方差
Mean1=mean(sortb1);%均值

[mu1,sigma1]=normfit(sortb1);
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%文件读取
name2 = 'Stopruntime_route_80020_time_other_3_4.txt';
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
name3 = 'Stopruntime_route_80050_time_other_3_4.txt';
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
name4 = 'Stopruntime_route_80010_time_other_3_4.txt';
fid4=fopen(name4,'r');%文件名string怎么赋值？
a4=textscan(fid4,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b4=a4{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table6=tabulate(b4(:));
%获取峰值
k=0;
s=0;
r=0;
maxt4=max(table6(:,3));
maxtime4=max(table6(:,1));
for t=1:maxtime4
    if table6(t,3) == maxt4
        break;
    end
end

%峰值前半段判断
for j=1:t
    p=table6(j,3);
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
newtable4=table6(j:i,:);
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
name5 = 'Stopruntime_route_80090_time_other_3_4.txt';
fid5=fopen(name5,'r');%文件名string怎么赋值？
a5=textscan(fid5,'%s %s %d %f   %s %d %d %s %s %d   %s %d %d %s %s %d   %s');
b5=a5{4};

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%错误或偶然数据的排除
table6=tabulate(b5(:));
%获取峰值
k=0;
s=0;
r=0;
maxt5=max(table6(:,3));
maxtime5=max(table6(:,1));
for t=1:maxtime5
    if table6(t,3) == maxt5
        break;
    end
end

%峰值前半段判断
for j=1:t
    p=table6(j,3);
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
newtable5=table6(j:i,:);
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
name6 = 'Stopruntime_route_80060_time_other_3_4.txt';
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
maxf6=max(f6);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%样本方差均值的计算
Delta6=var(sortb6);%方差
Mean6=mean(sortb6);%均值

%正态分布拟合判断

alpha=0.05;
[mu6,sigma6]=normfit(sortb6);




%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

figure(1);
%绘图

maxfn=max(maxf1,maxf2,maxf3,maxf4,maxf5,maxf6);
minst2=min(minst1,minst2,minst3,minst4,minst5,minst6);
maxst2=max(maxst1,maxst2,maxst3,maxst4,maxst5,maxst6);
%ksdensity
plot(xi1,f1,'g.-','LineWidth',3,xi2,f2,'b.-','LineWidth',3,xi3,f3,'r.-','LineWidth',3,xi4,f4,'m.-','LineWidth',3,xi5,f5,'c.-','LineWidth',3,xi6,f6,'r.-','LineWidth',3);
hold on;

axis([minst2,maxst2,0,maxfn*1.4]);
box off
title('Stopruntime time other stop 3-4');
xlabel('time(s)')
ylabel('F-出现的次数')
legend('\fontsize{8}\it 80022','\fontsize{8}\it 80020','\fontsize{8}\it 80050','\fontsize{8}\it 80010','\fontsize{8}\it 80090','\fontsize{8}\it 80060');
