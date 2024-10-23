package com.example.descubrelasestaciones

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.RecyclerView

class ColoresEstaciones: AppCompatActivity()
{
    object estacionesConstats
    {
        const val AVATAR = "AVATAR"
    }

    val itemsEstaciones = mutableListOf(ItemEstaciones(1,"Amarillo",42),
                                        ItemEstaciones(2,"Rosa",42),
                                        ItemEstaciones(3,"Naranja",42),
                                        ItemEstaciones(4,"Azul_Cielo",42))
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.colores_estaciones)

        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewColores)
        val adapter = ItemEstacionesAdapter(this, itemsEstaciones)
        itemEstacionesList.adapter = adapter

        itemEstacionesList.layoutManager = GridLayoutManager(this,4)


    }

}