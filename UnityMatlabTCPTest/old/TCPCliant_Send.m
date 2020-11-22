clear;
clc;

data = 0.1;      %matlab は既定でdoubleでとる

send = uint8(zeros(1,8));       %初期化
fileID = fopen('senddata.bin','w');
fwrite(fileID,data,'double');
fileID = fopen('senddata.bin');
sendbytedata = fread(fileID);
% for i =1:8
%     strbit = bitget(sendbytedata(i),1:1:8);
%     strbit = fliplr(strbit);
%     bit      = num2str(strbit);
%     bit = strcat('0b',bit);     %2進数って意味をつける
%     bit = string(bit);
%     bit = erase(bit,' ');   %なぜか空白が挿入されていたので削除
%     send(i) = uint8(eval(bit));
% end
send = uint8(sendbytedata);
send = send';       %縦ベクトルになっているのが気になるので、横ベクトルにする

 while true
     t = tcpclient('127.0.0.1', 2001, 'ConnectTimeout', 10);     %Connet to TCP Server
    write(t,send);

     clear t;
    
     break;
 end
 
 
 