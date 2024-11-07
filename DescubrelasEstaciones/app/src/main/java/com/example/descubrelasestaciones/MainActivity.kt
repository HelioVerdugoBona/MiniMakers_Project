package com.example.descubrelasestaciones

import android.content.Intent
import android.media.MediaPlayer
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.AdapterView
import android.widget.GridView
import androidx.appcompat.app.AppCompatActivity


class MainActivity : AppCompatActivity() {

    private val arrayOfAvatares = mutableListOf(
        Avatar("Caballo",R.drawable.caballo),
        Avatar("Oveja",R.drawable.oveja),
        Avatar("Burro",R.drawable.burro),
        Avatar("Gallina",R.drawable.gallina),
        Avatar("Conejo",R.drawable.conejo),
        Avatar("Baca",R.drawable.baca),
        Avatar("Pollo",R.drawable.pollo),
        Avatar("Cerdo",R.drawable.cerdo))

    private var infoNen = InfoNen("Error","Error","Error","Error","Error",
        "Error","Error","Error","Error","Error")

    private lateinit var mediaPlayer: MediaPlayer

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        val gridOfAvatares = findViewById<GridView>(R.id.ArrayAvatares)

        val adapter = AvataresAdapter(this, R.layout.avatar_item, arrayOfAvatares)
        gridOfAvatares.adapter = adapter

        mediaPlayer = MediaPlayer.create(this, R.raw.musicafondo)

        if (mediaPlayer != null) {
            // Configurar la música para que se repita
            mediaPlayer.isLooping = true

            // Iniciar la reproducción
            mediaPlayer.start()
        } else {
            Log.e("MediaPlayerError", "MediaPlayer no se pudo inicializar.")
        }

        gridOfAvatares.onItemClickListener = AdapterView.OnItemClickListener { _, _, i, _ ->

            val intent = Intent(this, ColoresEstaciones::class.java)
            infoNen.avatar = arrayOfAvatares[i].nombre
            Log.d("Nombre Avatar", infoNen.avatar)
            intent.putExtra(ColoresEstaciones.ColoresConstats.INFONEN, infoNen)
            startActivity(intent)

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