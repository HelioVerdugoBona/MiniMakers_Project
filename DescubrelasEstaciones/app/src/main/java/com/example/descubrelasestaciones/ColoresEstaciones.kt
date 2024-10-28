package com.example.descubrelasestaciones

import android.os.Bundle
import android.widget.Toast
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

    private var click1 = false
    private var item_id = 0

    private val itemsEstaciones = mutableListOf(ItemEstaciones(1,"Amarillo",R.drawable.sol),
                                        ItemEstaciones(2,"Rosa",R.drawable.flor),
                                        ItemEstaciones(3,"Naranja",R.drawable.hoja),
                                        ItemEstaciones(4,"Azul_Cielo",R.drawable.coponieve))


    private val arrayEstacionVerano = mutableListOf(ItemEstaciones(1,"Verano",R.drawable.estiu))

    private val arrayEstacionPrimavera = mutableListOf(ItemEstaciones(2,"Primavera",R.drawable.primavera))

    private val arrayEstacionOtono = mutableListOf(ItemEstaciones(3,"Otoño",R.drawable.tardor))

    private val arrayEstacionInvierno = mutableListOf(ItemEstaciones(4,"Invierno",R.drawable.hivern))

     override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.colores_estaciones)

         val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewColores)
         val adapter = ItemsEstacionesAdapter(this, itemsEstaciones) { item ->
             Toast.makeText(this, "Clicked: ${item.nombreItem}", Toast.LENGTH_SHORT).show()
             click1 = true
             item_id = item.id
         }
         itemEstacionesList.adapter = adapter

        val estacionOtono = findViewById<RecyclerView>(R.id.recyclerViewOtono)
        var adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionOtono){ item ->
            if (click1){
                if (item.id == item_id){
                    Toast.makeText(this, "Bien", Toast.LENGTH_SHORT).show()
                    click1 = false
                }else{
                    Toast.makeText(this, "Mal", Toast.LENGTH_SHORT).show()
                }
            }
        }
         estacionOtono.adapter = adapterEstacion

        val estacionInvierno = findViewById<RecyclerView>(R.id.recyclerViewInvierno)
         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionInvierno) { item ->
             if (click1) {
                 if (item.id == item_id) {
                     Toast.makeText(this, "Bien", Toast.LENGTH_SHORT).show()
                     click1 = false
                 } else {
                     Toast.makeText(this, "Mal", Toast.LENGTH_SHORT).show()
                 }
             }
         }
         estacionInvierno.adapter = adapterEstacion

        val estacionVerano = findViewById<RecyclerView>(R.id.recyclerViewVernano)
         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionVerano) { item ->
             if (click1) {
                 if (item.id == item_id) {
                     Toast.makeText(this, "Bien", Toast.LENGTH_SHORT).show()
                     click1 = false
                 } else {
                     Toast.makeText(this, "Mal", Toast.LENGTH_SHORT).show()
                 }
             }
         }
         estacionVerano.adapter = adapterEstacion

        val estacionPrimavera = findViewById<RecyclerView>(R.id.recyclerViewPrimavera)
         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionPrimavera) { item ->
             if (click1) {
                 if (item.id == item_id) {
                     Toast.makeText(this, "Bien", Toast.LENGTH_SHORT).show()
                     click1 = false
                 } else {
                     Toast.makeText(this, "Mal", Toast.LENGTH_SHORT).show()
                 }
             }
         }
         estacionPrimavera.adapter = adapterEstacion

        itemEstacionesList.layoutManager = GridLayoutManager(this,4)

        estacionOtono.layoutManager = LinearLayoutManager(this)
        estacionInvierno.layoutManager = LinearLayoutManager(this)
        estacionVerano.layoutManager = LinearLayoutManager(this)
        estacionPrimavera.layoutManager = LinearLayoutManager(this)

         


    }

}