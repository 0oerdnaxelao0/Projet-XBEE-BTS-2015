package com.example.maxime.client_android;

import android.app.Service;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.app.PendingIntent;
import android.app.Notification;
import android.app.NotificationManager;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.IBinder;
import android.util.Log;
import android.widget.Toast;

import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.SocketException;
import android.os.Handler;
import java.util.logging.LogRecord;

/**
 * Created by maxime on 24/05/15.
 */
public class ServiceUDP extends Service {

    DatagramSocket datagramSocket;
    DatagramPacket packet;
    Boolean continuer = true;
    String message2;
    byte [] buffer = new byte[1024];
    final static String MY_ACTION = "MY_ACTION";
    public static final int ID_NOTIFICATION = 1988;


    @Override
    public void onCreate() {
        super.onCreate();
        try {
            datagramSocket = new DatagramSocket(5053);
        }
        catch (SocketException e)
        {

        }
        packet = new DatagramPacket(buffer,buffer.length);

    }
    @Override
    public void onDestroy()
    {
        super.onDestroy();
    }



    @Override
    public int onStartCommand (final Intent intent , int flags , int startID) {

        final String LOG_TAG = "MyClass";
        Log.w(LOG_TAG, "le startcommand s'est lancé");

        Thread UDPThread;
        UDPThread = new Thread(new Runnable() {
            @Override
            public void run() {
                while (continuer) {
                   try
                    {
                        datagramSocket.receive(packet);
                        Log.w(LOG_TAG, "le startcommand a recu");
                        final String message = new String(packet.getData(),0,packet.getLength());
                        message2=message +System.getProperty("line.separator");
                        Intent intent = new Intent();
                        intent.setAction(MY_ACTION);
                        intent.putExtra("DATAPASSED",message2);
                        sendBroadcast(intent);
                        Log.w(LOG_TAG, "le message est passé");

                        try {
                            FileOutputStream  out = openFileOutput("test15.txt",MODE_APPEND);
                            out.write(message2.getBytes());
                        }
                        catch (FileNotFoundException e)
                        {
                            e.printStackTrace();
                        }
                        catch (IOException e)
                        {
                            e.printStackTrace();
                        }

                    } catch (IOException e)
                    {
                        e.printStackTrace();
                    }
                    NotificationManager notificationManager = (NotificationManager)getSystemService(Context.NOTIFICATION_SERVICE);
                    Notification notification = new Notification(R.drawable.ic_launcher,"HoneyBee",System.currentTimeMillis());
                    Intent notifintent = new Intent(ServiceUDP.this,MainActivity.class);
                    PendingIntent pendingIntent = PendingIntent.getActivity(ServiceUDP.this,0,notifintent,0);
                    String bonjour = " HoneyBee";
                    String aurevoir = "De nouvelles données ont été transmises !";
                    notification.setLatestEventInfo(ServiceUDP.this,bonjour,aurevoir,pendingIntent);
                    notification.vibrate = new long[] {0,200,100,200,100,200};
                    notificationManager.notify(ID_NOTIFICATION, notification);

                }


            }
        });
        UDPThread.start();


        return Service.START_STICKY;
    }


    public IBinder onBind(Intent intent)
    {
        return null;
    }
}
