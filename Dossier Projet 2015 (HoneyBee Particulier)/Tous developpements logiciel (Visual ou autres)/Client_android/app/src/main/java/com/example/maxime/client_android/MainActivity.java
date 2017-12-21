package com.example.maxime.client_android;

import android.app.Activity;
import android.app.PendingIntent;
import android.util.Log;
import android.app.AlertDialog;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.Service;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.IBinder;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.DatagramSocketImpl;
import java.net.Socket;
import java.net.SocketException;
import android.os.PowerManager;



public class MainActivity extends ActionBarActivity {

    TextView poids,tension,temperature;
    Button suivi;
    String line;
    ImageView i_poids,i_tension,i_temperature;
    MyReceiver myReceiver;
    PowerManager.WakeLock wakeLock;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        i_tension =(ImageView)findViewById(R.id.i_tension);
        i_tension.setImageResource(R.drawable.eclair);

        i_poids =(ImageView)findViewById(R.id.i_poids);
        i_poids.setImageResource(R.drawable.balance);

        i_temperature =(ImageView)findViewById(R.id.i_temperature);
        i_temperature.setImageResource(R.drawable.thermometre);

        suivi = (Button) findViewById(R.id.suivi_j);
        poids = (TextView) findViewById(R.id.poids);
        tension = (TextView) findViewById(R.id.tension);
        temperature = (TextView) findViewById(R.id.temperature);
        suivi.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(MainActivity.this,Suivi_Journalier.class);
                startActivity(intent);
            }
        });


        try {

            FileInputStream fstream = openFileInput("test15.txt");
            DataInputStream in = new DataInputStream(fstream);
            BufferedReader br = new BufferedReader(new InputStreamReader(in));
            String lastLine="";

            while ((line=br.readLine())!=null)
            {
                lastLine=line;
            }


            String str [] = lastLine.split(" ");
            poids.setText(str[2]+"kg");
            tension.setText(str[4]+"%");
            temperature.setText(str[3]+"°");

        }
        catch (FileNotFoundException e)
        {
            e.printStackTrace();
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }

    }

    private class MyReceiver extends BroadcastReceiver {

        @Override
        public void onReceive(Context arg0 , Intent arg1)
        {
            Bundle bundle;
            bundle = arg1.getExtras();
            String Smessage = bundle.getString("DATAPASSED");
            final String str [] = Smessage.split(" ");
            poids.setText(str[2]+"kg");
            tension.setText(str[4]+"%");
            temperature.setText(str[3]+"°");
        }
    }



    @Override
    public void onBackPressed(){

        new AlertDialog.Builder(this)
                .setTitle("Quitter ?")
                .setMessage("etes vous sur de vouloir quitter ? ")
                .setNegativeButton(android.R.string.no, null)
                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        MainActivity.super.onBackPressed();
                        System.exit(0);
                    }
                }).create().show();
    }

    @Override
    public void onDestroy()
    {
        super.onDestroy();
    }

    @Override
    public void onStart()
    {
        PowerManager pm=(PowerManager)getSystemService(Context.POWER_SERVICE);
        wakeLock = pm.newWakeLock(PowerManager.PARTIAL_WAKE_LOCK,"monwakelock");

        myReceiver = new MyReceiver();
        IntentFilter intentFilter = new IntentFilter();
        intentFilter.addAction(ServiceUDP.MY_ACTION);
        registerReceiver(myReceiver, intentFilter);

        Intent intent = new Intent(MainActivity.this,ServiceUDP.class);
        startService(intent);
        super.onStart();
    }



}

