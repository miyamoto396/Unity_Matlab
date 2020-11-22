clear;
clc;

 while true     
     t = tcpclient('127.0.0.1', 2001, 'ConnectTimeout', 10);     %Connet to TCP Server
    data = read(t,1,'double');  %値を読み出す
    disp(data);
     
    clear t;
    
    break;
 end