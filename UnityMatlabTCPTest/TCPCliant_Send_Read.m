clear;
clc;

data = 0.1;      %matlab は既定でdoubleでとる

% Matlabから送るための処理
fileID = fopen('senddata.bin','w');     %書き込むデータを一度ファイルに書き込む
fwrite(fileID,data,'double');                %doubleを8byteにわけておくるためにbinで書き込む             
fileID = fopen('senddata.bin'); 
sendbytedata = fread(fileID);
send = uint8(sendbytedata);
send = send';       %縦ベクトルになっているのが気になるので、横ベクトルにする

 while true
    SendTCP = tcpclient('127.0.0.1', 2001, 'ConnectTimeout', 10);     %Connet to TCP Server
    write(SendTCP,send);
    
     ReadTCP =  tcpclient('127.0.0.1', 2000, 'ConnectTimeout', 10);
     readdata = read(ReadTCP,1,'double');  %値を読み出す
     disp(readdata);
    
     clear t;
    
     break;
 end
 
 
 