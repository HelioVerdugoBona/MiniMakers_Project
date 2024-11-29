package com.example.descubrelasestaciones.niveles

import android.content.Intent
import android.icu.util.Calendar
import android.media.MediaPlayer
import android.os.Build
import android.os.Bundle
import android.view.View
import android.widget.Button
import androidx.annotation.RequiresApi
import androidx.appcompat.app.AppCompatActivity
import com.example.descubrelasestaciones.misc.BackgroundSound
import com.example.descubrelasestaciones.misc.FileManager
import com.example.descubrelasestaciones.MainActivity
import com.example.descubrelasestaciones.R
import com.example.descubrelasestaciones.classes.Avatar
import com.example.descubrelasestaciones.niveles.ColoresEstaciones.ColoresConstats
import com.example.descubrelasestaciones.classes.InfoNen
import java.text.SimpleDateFormat
import java.time.LocalDateTime
import java.time.ZonedDateTime

class PantallaFinal:AppCompatActivity()
{

    object InfoNens {
        const val INFONEN = "INFONEN"
    }
    private var infoNen = InfoNen("Exemple",0,0,0,0,
        0.00,0,0,0,0,"Exemple","Exemple")
    private var arrayInfoNen = mutableListOf<InfoNen>()

    private lateinit var aconseguit: MediaPlayer

    @RequiresApi(Build.VERSION_CODES.O)
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.final_layout)
        window.decorView.systemUiVisibility = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)
        aconseguit = MediaPlayer.create(this, R.raw.felicitats)
        aconseguit.start()

        val buttonVolver = findViewById<Button>(R.id.buttonTerminar)
        val intent = intent
        infoNen = intent.getSerializableExtra(ColoresConstats.INFONEN) as InfoNen
        setAllInformation(infoNen)
        buttonVolver.setOnClickListener {
            endMusic()
            finish()
        }
    }

    private fun endMusic() {
        val intent = Intent(this, BackgroundSound::class.java)
        stopService(intent)
    }

    @RequiresApi(Build.VERSION_CODES.O)
    private fun setAllInformation(infoNen: InfoNen) {
        val tmpTotal = infoNen.tempsNVL1 + infoNen.tempsNVL2 + infoNen.tempsNVL3
        infoNen.tempsTotal = tmpTotal
        infoNen.tempsProm = (tmpTotal/3).toDouble()
        infoNen.data = SimpleDateFormat("dd/MM/yyyy").format(Calendar.getInstance().getTime());
        infoNen.hora= SimpleDateFormat("HH:mm:ss").format(Calendar.getInstance().getTime());

        val intentosTotal = infoNen.erradesNVL1 + infoNen.erradesNVL2 + infoNen.erradesNVL3
        infoNen.erradesTotals = intentosTotal
        println("La Info total es:" + " Avatar: " + infoNen.avatar + " Tiempo nivel 1: " + infoNen.tempsNVL1
                + " Tiempo nivel 2: " + infoNen.tempsNVL2 + " Tiempo nivel 3: " + infoNen.tempsNVL3
                + " Tiempo Total: " + infoNen.tempsTotal + " Tiempo Promedio: " + infoNen.tempsProm
                + " Intentos Nivel 1: " + infoNen.erradesNVL1 + " Intentos Nivel 2: " + infoNen.erradesNVL2
                + " Intentos Nivel 3: " + infoNen.erradesNVL3 + " IntentosTotales: " + infoNen.erradesTotals)

        if(!FileManager.comproveFile(this))
        {
            var exemple = InfoNen("Exemple",0,0,0,0,
                0.00,0,0,0,0,"Exemple","Exemple")
            arrayInfoNen.add(exemple)
            FileManager.saveUsersStats(this, arrayInfoNen)
        }

        arrayInfoNen = FileManager.getUsersStats(this) as ArrayList<InfoNen>
        arrayInfoNen.add(infoNen)
        FileManager.saveUsersStats(this, arrayInfoNen)
    }
}