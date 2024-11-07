package com.example.descubrelasestaciones

import android.content.Intent
import android.media.MediaPlayer
import android.os.Bundle
import android.util.Log
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import com.example.descubrelasestaciones.ColoresEstaciones.ColoresConstats

class PantallaFinal:AppCompatActivity()
{

    object InfoNens {
        const val INFONEN = "INFONEN"
    }

    private var infoNen = InfoNen("Error","Error","Error","Error","Error",
        "Error","Error","Error","Error","Error")

    private var arrayInfoNen = mutableListOf<InfoNen>()

    private lateinit var mediaPlayer: MediaPlayer

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.final_layout)

        if (mediaPlayer != null) {
            // Configurar la música para que se repita
            mediaPlayer.isLooping = true

            // Iniciar la reproducción
            mediaPlayer.start()
        } else {
            Log.e("MediaPlayerError", "MediaPlayer no se pudo inicializar.")
        }

        val buttonVolver = findViewById<Button>(R.id.buttonTerminar)

        val intent = intent
        infoNen = intent.getSerializableExtra(ColoresConstats.INFONEN) as InfoNen
        setAllInformation(infoNen)
        buttonVolver.setOnClickListener {
            val intent = Intent(this, MainActivity::class.java) // Reemplaza `MainActivity` con la actividad que deseas abrir
            intent.flags = Intent.FLAG_ACTIVITY_NEW_TASK or Intent.FLAG_ACTIVITY_CLEAR_TASK
            startActivity(intent)
            finish()
        }

    }

    private fun setAllInformation(infoNen: InfoNen) {
        val tmpTotal = infoNen.tempsNVL1.toInt() + infoNen.tempsNVL2.toInt() + infoNen.tempsNVL3.toInt()
        infoNen.tempsTotal = tmpTotal.toString()
        infoNen.tempsProm = (tmpTotal/3).toString()
        val intentosTotal = infoNen.erradesNVL1.toInt() + infoNen.erradesNVL2.toInt() + infoNen.erradesNVL3.toInt()
        infoNen.erradesTotals = intentosTotal.toString()
        println("La Info total es:" + " Avatar: " + infoNen.avatar + " Tiempo nivel 1: " + infoNen.tempsNVL1
                + " Tiempo nivel 2: " + infoNen.tempsNVL2 + " Tiempo nivel 3: " + infoNen.tempsNVL3
                + " Tiempo Total: " + infoNen.tempsTotal + " Tiempo Promedio: " + infoNen.tempsProm
                + " Intentos Nivel 1: " + infoNen.erradesNVL1 + " Intentos Nivel 2: " + infoNen.erradesNVL2
                + " Intentos Nivel 3: " + infoNen.erradesNVL3 + " IntentosTotales: " + infoNen.erradesTotals)


        if(!FileManager.comproveFile(this))
        {
            val exemple = InfoNen("Exemple","Exemple","Exemple",
                "Exemple","Exemple","Exemple","Exemple",
                "Exemple","Exemple","Exemple")

            arrayInfoNen.add(exemple)

            FileManager.saveUsersStats(this,arrayInfoNen)

        }else{
            arrayInfoNen = FileManager.getUsersStats(this) as ArrayList<InfoNen>
            arrayInfoNen.add(infoNen)
            FileManager.saveUsersStats(this,arrayInfoNen)
        }
    }
    override fun onResume() {
        super.onResume()
        // Reiniciar la música si se detuvo al pausar la aplicación
        if (!mediaPlayer.isPlaying) {
            mediaPlayer.start()
        }
    }

    override fun onPause() {
        super.onPause()
        // Pausar la música cuando la actividad no esté visible
        mediaPlayer.pause()
    }

    override fun onDestroy() {
        super.onDestroy()
        // Liberar el MediaPlayer para evitar fugas de memoria
        mediaPlayer.release()
    }
}