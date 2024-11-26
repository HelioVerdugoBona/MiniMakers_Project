package com.example.descubrelasestaciones.niveles

import android.content.Intent
import android.media.MediaPlayer
import android.os.Bundle
import android.view.View
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import com.example.descubrelasestaciones.misc.BackgroundSound
import com.example.descubrelasestaciones.misc.FileManager
import com.example.descubrelasestaciones.MainActivity
import com.example.descubrelasestaciones.R
import com.example.descubrelasestaciones.niveles.ColoresEstaciones.ColoresConstats
import com.example.descubrelasestaciones.classes.InfoNen

class PantallaFinal:AppCompatActivity()
{

    object InfoNens {
        const val INFONEN = "INFONEN"
    }
    private var infoNen = InfoNen("Error",0,0,0,0,
        0.00,"Error","Error","Error","Error")
    private var arrayInfoNen = mutableListOf<InfoNen>()

    private lateinit var aconseguit: MediaPlayer

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
            val intent = Intent(this, MainActivity::class.java) // Reemplaza `MainActivity` con la actividad que deseas abrir
            intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
            endMusic()
            startActivity(intent)
            finish()
        }
    }

    private fun endMusic() {
        val intent = Intent(this, BackgroundSound::class.java)
        stopService(intent)
    }

    private fun setAllInformation(infoNen: InfoNen) {
        val tmpTotal = infoNen.tempsNVL1 + infoNen.tempsNVL2 + infoNen.tempsNVL3
        infoNen.tempsTotal = tmpTotal
        infoNen.tempsProm = (tmpTotal/3).toDouble()
        val intentosTotal = infoNen.erradesNVL1.toInt() + infoNen.erradesNVL2.toInt() + infoNen.erradesNVL3.toInt()
        infoNen.erradesTotals = intentosTotal.toString()
        println("La Info total es:" + " Avatar: " + infoNen.avatar + " Tiempo nivel 1: " + infoNen.tempsNVL1
                + " Tiempo nivel 2: " + infoNen.tempsNVL2 + " Tiempo nivel 3: " + infoNen.tempsNVL3
                + " Tiempo Total: " + infoNen.tempsTotal + " Tiempo Promedio: " + infoNen.tempsProm
                + " Intentos Nivel 1: " + infoNen.erradesNVL1 + " Intentos Nivel 2: " + infoNen.erradesNVL2
                + " Intentos Nivel 3: " + infoNen.erradesNVL3 + " IntentosTotales: " + infoNen.erradesTotals)

        if(!FileManager.comproveFile(this))
        {
            val exemple = InfoNen("Error",0,0,0,0,
            0.00,"Error","Error","Error","Error")
            arrayInfoNen.add(exemple)
            FileManager.saveUsersStats(this, arrayInfoNen)
        }

        arrayInfoNen = FileManager.getUsersStats(this) as ArrayList<InfoNen>
        arrayInfoNen.add(infoNen)
        FileManager.saveUsersStats(this, arrayInfoNen)
    }
}