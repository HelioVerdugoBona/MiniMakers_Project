package com.example.descubrelasestaciones

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.descubrelasestaciones.adapters.AvataresAdapter
import com.example.descubrelasestaciones.classes.Avatar
import com.example.descubrelasestaciones.classes.InfoNen
import com.example.descubrelasestaciones.misc.BackgroundSound
import com.example.descubrelasestaciones.niveles.Tutorial


class MainActivity : AppCompatActivity() {

    private val arrayOfAvatares = mutableListOf(
        Avatar("Caballo",R.drawable.caballo),
        Avatar("Oveja",R.drawable.oveja),
        Avatar("Burro",R.drawable.burro),
        Avatar("Gallina",R.drawable.gallina),
        Avatar("Conejo",R.drawable.conejo),
        Avatar("Vaca",R.drawable.vaca),
        Avatar("Pollo",R.drawable.pollo),
        Avatar("Cerdo",R.drawable.cerdo)
    )

    private var infoNen = InfoNen("Error",0,0,0,0,
        0.00,"Error","Error","Error","Error")

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        window.decorView.systemUiVisibility =
            (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        startMusic()

        val recyclerViewAvatares = findViewById<RecyclerView>(R.id.ArrayAvatares)

        val adapter = AvataresAdapter(this, arrayOfAvatares){ avatar ->

            val intent = Intent(this, Tutorial::class.java)
            infoNen.avatar = avatar.nombre
            Log.d("Nombre Avatar", infoNen.avatar)
            intent.putExtra(Tutorial.TutoriaConstats.INFONEN, infoNen)
            startActivity(intent)

        }
        recyclerViewAvatares.adapter = adapter
        recyclerViewAvatares.layoutManager = GridLayoutManager(this,4)
    }

    private fun startMusic() {
        val intent = Intent(this, BackgroundSound::class.java)
        startService(intent)
    }
}