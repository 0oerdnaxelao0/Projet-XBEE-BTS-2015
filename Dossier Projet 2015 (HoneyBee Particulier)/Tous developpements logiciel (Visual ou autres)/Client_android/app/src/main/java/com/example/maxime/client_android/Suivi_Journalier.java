package com.example.maxime.client_android;

import android.app.ActionBar;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.Notification;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.FragmentActivity;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;
import java.lang.String;
import static java.lang.System.*;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

/**
 * Created by maxime on 13/03/15.
 */
public class Suivi_Journalier extends ActionBarActivity {

    private Button rechercher;
    private Button change_date;
    TextView poids, tension, temperature;
    EditText txtDate;
    RadioGroup groupe;
    String heure;
    ImageView i_poids,i_tension,i_temperature;
    static final int DATE_DIALOG_ID = 100;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.suivi);

        i_tension =(ImageView)findViewById(R.id.i_tension);
        i_tension.setImageResource(R.drawable.eclair);

        i_poids =(ImageView)findViewById(R.id.i_poids);
        i_poids.setImageResource(R.drawable.balance);

        i_temperature =(ImageView)findViewById(R.id.i_temperature);
        i_temperature.setImageResource(R.drawable.thermometre);

        addbouton();
    }


    public void addbouton()
    {
        change_date = (Button)findViewById(R.id.b_changedate);
        change_date.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showDialog(DATE_DIALOG_ID);
            }
        });

        rechercher = (Button)findViewById(R.id.b_rechercher);
        rechercher.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String line ="";
                txtDate= (EditText)findViewById(R.id.txtdate);
                poids = (TextView)findViewById(R.id.poids);
                tension = (TextView)findViewById(R.id.tension);
                temperature= (TextView)findViewById(R.id.temperature);
                groupe = (RadioGroup)findViewById(R.id.groupe);
                change_date = (Button)findViewById(R.id.b_changedate);

                try {
                    FileInputStream fstream = openFileInput("test15.txt");
                    DataInputStream in = new DataInputStream(fstream);
                    BufferedReader br = new BufferedReader(new InputStreamReader(in));
                    while ((line=br.readLine())!=null)
                    {
                        String Txtdate=txtDate.getText().toString();
                        String str [] = line.split(" ");




                        if (groupe.getCheckedRadioButtonId() == R.id.choix1)
                        {
                            heure = "matin";
                        }
                        else if (groupe.getCheckedRadioButtonId()== R.id.choix2)
                        {
                            heure ="soir";
                        }


                        if (Txtdate.equals("") && groupe.getCheckedRadioButtonId()== -1 )
                        {
                            Toast.makeText(Suivi_Journalier.this,"Vous n'avez pas choisi de date ni d'heure",Toast.LENGTH_LONG).show();
                        }
                        else if (groupe.getCheckedRadioButtonId()== -1)
                        {
                            Toast.makeText(Suivi_Journalier.this,"Vous n'avez pas choisi d'heure :)",Toast.LENGTH_LONG).show();
                        }
                        else if (Txtdate.equals(""))
                        {
                            Toast.makeText(Suivi_Journalier.this,"Vous n'avez pas choisi de date :)",Toast.LENGTH_LONG).show();
                        }
                        else if (str[0].equals(Txtdate) && str[1].equals(heure))
                        {
                            poids.setText(str[2]+"kg");
                            tension.setText(str[4]+"%");
                            temperature.setText(str[3]+"°");
                        }



                    }


                }
                catch (FileNotFoundException e)
                {
                    e.printStackTrace();
                }
                catch (IOException e)
                {
                    e.printStackTrace();
                }

                if(poids.getText().toString().equals("") && tension.getText().toString().equals("") && temperature.getText().toString().equals("") && groupe.getCheckedRadioButtonId()!= -1 && !txtDate.getText().toString().equals(""))
                {
                    Toast.makeText(Suivi_Journalier.this,"aucune donnée n'a été trouvé pour cette date",Toast.LENGTH_LONG).show();
                }



            }
        });



    }
        @Override
        protected Dialog onCreateDialog(int id)
        {
            switch (id){
                case DATE_DIALOG_ID:

                    Calendar c =Calendar.getInstance();
                    int year = c.get(Calendar.YEAR);
                    int month = c.get(Calendar.MONTH);
                    int day = c.get(Calendar.DAY_OF_MONTH);

                    return new DatePickerDialog(this, datePickerlistener, year,month,day);


            }
            return null;
        }

    private DatePickerDialog.OnDateSetListener datePickerlistener = new DatePickerDialog.OnDateSetListener(){

        public void onDateSet(DatePicker view , int syear,int smonth , int sday)
        {
            String jour , mois , annee,complet;
            txtDate= (EditText)findViewById(R.id.txtdate);
            jour = String.valueOf(sday);
            mois = String.valueOf(smonth+1);
            annee=String.valueOf(syear);
            complet = jour+"/"+mois+"/"+annee;
            txtDate.setText(complet);


        }
    };

    };






