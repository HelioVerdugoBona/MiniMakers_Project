package com.example.descubrelasestaciones

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class ColoresEstaciones: AppCompatActivity()
{
    object estacionesConstats
    {
        const val AVATAR = "AVATAR"
    }

    val itemsEstaciones = mutableListOf(ItemEstaciones(1,"Amarillo",R.drawable.descarga),
                                        ItemEstaciones(2,"Rosa",R.drawable.descarga),
                                        ItemEstaciones(3,"Naranja",R.drawable.descarga),
                                        ItemEstaciones(4,"Azul_Cielo",R.drawable.descarga))

    val estaciones = mutableListOf(ItemEstaciones(1,"Amarillo",R.drawable.descarga))

     override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.colores_estaciones)

        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewColores)
        val adapter = ItemsEstacionesAdapter(this, itemsEstaciones)
        itemEstacionesList.adapter = adapter

        val estacionOtono = findViewById<RecyclerView>(R.id.recyclerViewOtono)
        var adapterEstacion = MultiEstacionesAdapter(this, estaciones)
         estacionOtono.adapter = adapterEstacion

        val estacionInvierno = findViewById<RecyclerView>(R.id.recyclerViewInvierno)
         adapterEstacion = MultiEstacionesAdapter(this, estaciones)
         estacionInvierno.adapter = adapterEstacion

        val estacionVernano = findViewById<RecyclerView>(R.id.recyclerViewVernano)
         adapterEstacion = MultiEstacionesAdapter(this, estaciones)
         estacionVernano.adapter = adapterEstacion

        val estacionPrimavera = findViewById<RecyclerView>(R.id.recyclerViewPrimavera)
         adapterEstacion = MultiEstacionesAdapter(this, estaciones)
         estacionPrimavera.adapter = adapterEstacion


        itemEstacionesList.layoutManager = GridLayoutManager(this,4)

        estacionOtono.layoutManager = LinearLayoutManager(this)
        estacionInvierno.layoutManager = LinearLayoutManager(this)
        estacionVernano.layoutManager = LinearLayoutManager(this)
        estacionPrimavera.layoutManager = LinearLayoutManager(this)

    }

}