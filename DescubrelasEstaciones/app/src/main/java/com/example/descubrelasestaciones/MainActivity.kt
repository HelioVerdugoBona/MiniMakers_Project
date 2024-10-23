package com.example.descubrelasestaciones

import android.content.Intent
import android.os.Bundle
import android.widget.AdapterView
import android.widget.GridView
import androidx.appcompat.app.AppCompatActivity


class MainActivity : AppCompatActivity() {

    private val arrayOfAvatares = mutableListOf(
        Avatar("Avatar1",R.drawable.descarga),
        Avatar("Avatar2",R.drawable.descarga),
        Avatar("Avatar3",R.drawable.descarga),
        Avatar("Avatar4",R.drawable.descarga),
        Avatar("Avatar5",R.drawable.descarga),
        Avatar("Avatar6",R.drawable.descarga),
        Avatar("Avatar7",R.drawable.descarga),
        Avatar("Avatar8",R.drawable.descarga))



    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val gridOfAvatares = findViewById<GridView>(R.id.ArrayAvatares)

        val adapter = AvataresAdapter(this,R.layout.avatar_item,arrayOfAvatares)

        gridOfAvatares.adapter = adapter

        gridOfAvatares.onItemClickListener = AdapterView.OnItemClickListener()
        {
                _, _, i, _ ->
            val intent = Intent(this, ColoresEstaciones::class.java)

            val avatarElejido = arrayOfAvatares[i]
            intent.putExtra(ColoresEstaciones.estacionesConstats.AVATAR, avatarElejido.nombre)
            startActivity(intent)


        }

    }
}