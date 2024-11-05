package com.example.descubrelasestaciones

import android.content.Intent
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

    private var infoNen = InfoNen("Hola","","","","",
        "","","","","")

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        window.decorView.systemUiVisibility = (View.SYSTEM_UI_FLAG_FULLSCREEN or View.SYSTEM_UI_FLAG_HIDE_NAVIGATION or View.SYSTEM_UI_FLAG_IMMERSIVE_STICKY)

        val gridOfAvatares = findViewById<GridView>(R.id.ArrayAvatares)

        val adapter = AvataresAdapter(this,R.layout.avatar_item,arrayOfAvatares)
        gridOfAvatares.adapter = adapter

        gridOfAvatares.onItemClickListener = AdapterView.OnItemClickListener { _, _, i, _ ->

            val intent = Intent(this, ColoresEstaciones::class.java)
            infoNen.avatar = arrayOfAvatares[i].nombre
            Log.d("Nombre Avatar",infoNen.avatar)
            intent.putExtra(ColoresEstaciones.EstacionesConstats.AVATAR, infoNen.avatar)
            startActivity(intent)
        }
    }
}