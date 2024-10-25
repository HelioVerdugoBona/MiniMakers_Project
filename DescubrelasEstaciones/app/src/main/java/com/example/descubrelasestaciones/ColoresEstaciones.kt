package com.example.descubrelasestaciones

import android.os.Bundle
import android.widget.AdapterView
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class ColoresEstaciones: AppCompatActivity()
{
    object EstacionesConstats
    {
        const val AVATAR = "AVATAR"
    }

    private val itemsEstaciones = mutableListOf(ItemEstaciones(1,"Amarillo",R.drawable.descarga),
                                        ItemEstaciones(2,"Rosa",R.drawable.descarga),
                                        ItemEstaciones(3,"Naranja",R.drawable.descarga),
                                        ItemEstaciones(4,"Azul_Cielo",R.drawable.descarga))

    private val arrayEstacionOtono = mutableListOf(ItemEstaciones(1,"Otoño",R.drawable.tardor))

    private val arrayEstacionInvierno = mutableListOf(ItemEstaciones(2,"Invierno",R.drawable.hivern))

    private val arrayEstacionVerano = mutableListOf(ItemEstaciones(3,"Verano",R.drawable.estiu))

    private val arrayEstacionPrimavera = mutableListOf(ItemEstaciones(4,"Primavera",R.drawable.primavera))

     override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.colores_estaciones)

        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewColores)
        val adapter = ItemsEstacionesAdapter(this, itemsEstaciones)
        itemEstacionesList.adapter = adapter

        /*
        val estacionOtono = findViewById<RecyclerView>(R.id.recyclerViewOtono)
        var adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionOtono)
         estacionOtono.adapter = adapterEstacion

        val estacionInvierno = findViewById<RecyclerView>(R.id.recyclerViewInvierno)
         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionInvierno)
         estacionInvierno.adapter = adapterEstacion

        val estacionVerano = findViewById<RecyclerView>(R.id.recyclerViewVernano)
         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionVerano)
         estacionVerano.adapter = adapterEstacion

        val estacionPrimavera = findViewById<RecyclerView>(R.id.recyclerViewPrimavera)
         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionPrimavera)
         estacionPrimavera.adapter = adapterEstacion


        itemEstacionesList.layoutManager = GridLayoutManager(this,4)

        estacionOtono.layoutManager = LinearLayoutManager(this)
        estacionInvierno.layoutManager = LinearLayoutManager(this)
        estacionVerano.layoutManager = LinearLayoutManager(this)
        estacionPrimavera.layoutManager = LinearLayoutManager(this)
        */
         
         itemEstacionesList.onItemClickListener = AdapterView.OnItemClickListener() 
         {
                 _, _, i, _ ->
             
         }

    }

}