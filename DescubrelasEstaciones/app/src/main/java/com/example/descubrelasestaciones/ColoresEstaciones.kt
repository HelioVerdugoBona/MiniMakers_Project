package com.example.descubrelasestaciones

import android.content.ClipData
import android.os.Bundle
import android.util.Log
import android.view.DragEvent
import android.view.View
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class ColoresEstaciones: AppCompatActivity() {

    object EstacionesConstats {
        const val AVATAR = "AVATAR"
    }

    private val itemsEstaciones = mutableListOf(
        ItemEstaciones("1", "Amarillo", R.drawable.descarga),
        ItemEstaciones("2", "Rosa", R.drawable.descarga),
        ItemEstaciones("3", "Naranja", R.drawable.descarga),
        ItemEstaciones("4", "Azul_Cielo", R.drawable.descarga)
    )

<<<<<<< Updated upstream
    private val itemsEstaciones = mutableListOf(ItemEstaciones(1,"Amarillo",R.drawable.sol),
                                        ItemEstaciones(2,"Rosa",R.drawable.flor),
                                        ItemEstaciones(3,"Naranja",R.drawable.hoja),
                                        ItemEstaciones(4,"Azul_Cielo",R.drawable.coponieve))
=======
    private val arrayEstaciones = mutableListOf(
        ItemEstaciones("1", "Verano", R.drawable.estiu),
        ItemEstaciones("2", "Primavera", R.drawable.primavera),
        ItemEstaciones("3", "Otoño", R.drawable.tardor),
        ItemEstaciones("4", "Invierno", R.drawable.hivern)
    )
>>>>>>> Stashed changes

    val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewColores)
    val arrayEstacionesList = findViewById<RecyclerView>(R.id.recylerViewEstaciones)

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.colores_estaciones)

        setupRecyclerView(itemEstacionesList, itemsEstaciones)
        setupRecyclerView(arrayEstacionesList, arrayEstaciones)
    }

    private fun setupRecyclerView(
        recyclerView: RecyclerView,
        itemsEstaciones: MutableList<ItemEstaciones>
    ) {
        val adapter = ItemsEstacionesAdapter(this, itemsEstaciones)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.layoutManager = GridLayoutManager(this,4)
        recyclerView.adapter = adapter

        if (recyclerView == itemEstacionesList) {
            adapter.setOnLongClickListener { view, i ->
                val item = itemsEstaciones[i]

                // Inicia el arrastre con una sombra personalizada
                val dragData = ClipData.newPlainText("id", item.id)
                val dragShadow = CustomDragShadowBuilder(view) // Usar la sombra personalizada
                view.startDragAndDrop(dragData, dragShadow, view, 0)
            }
        }
        if (recyclerView == arrayEstacionesList) {
            recyclerView.setOnDragListener { _, event ->
                when (event.action) {
                    DragEvent.ACTION_DROP -> {
                        // Obtener el atributo del ítem arrastrado
                        val draggedAttribute = event.clipData.getItemAt(0).text.toString()

                        // Encuentra el ítem de destino (donde se soltó el arrastre)
                        val targetPosition = recyclerView.getChildAdapterPosition(event.localState as View)
                        if (targetPosition != RecyclerView.NO_POSITION) {
                            val targetItem = arrayEstaciones[targetPosition]

                            // Compara los atributos
                            if (draggedAttribute == targetItem.id) {
                                Log.d("DragAndDrop", "Atributos coinciden")
                            } else {
                                Log.d("DragAndDrop", "Atributos no coinciden")
                            }
                        }
                        true
                    }
                    DragEvent.ACTION_DRAG_ENDED -> {
                        // Restablecer la opacidad del ítem arrastrado
                        adapter.clearAlpha() // Restablecer la opacidad de todos los ítems
                        true
                    }
                    else -> true
                }
            }
        }
    }
}



//         val adapter = ItemsEstacionesAdapter(this, itemsEstaciones) { item ->
//             Toast.makeText(this, "Clicked: ${item.nombreItem}", Toast.LENGTH_SHORT).show()
//             click1 = true
//             item_id = item.id
//         }
//         itemEstacionesList.adapter = adapter
//
//         var adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionOtono){ item ->
//            if (click1){
//                if (item.id == item_id){
//                    Toast.makeText(this, "Bien", Toast.LENGTH_SHORT).show()
//                    click1 = false
//                }else{
//                    Toast.makeText(this, "Mal", Toast.LENGTH_SHORT).show()
//                }
//            }
//        }
//         estacionOtono.adapter = adapterEstacion
//
//         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionInvierno) { item ->
//             if (click1) {
//                 if (item.id == item_id) {
//                     Toast.makeText(this, "Bien", Toast.LENGTH_SHORT).show()
//                     click1 = false
//                 } else {
//                     Toast.makeText(this, "Mal", Toast.LENGTH_SHORT).show()
//                 }
//             }
//         }
//         estacionInvierno.adapter = adapterEstacion
//
//
//         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionVerano) { item ->
//             if (click1) {
//                 if (item.id == item_id) {
//                     Toast.makeText(this, "Bien", Toast.LENGTH_SHORT).show()
//                     click1 = false
//                 } else {
//                     Toast.makeText(this, "Mal", Toast.LENGTH_SHORT).show()
//                 }
//             }
//         }
//         estacionVerano.adapter = adapterEstacion
//
//
//         adapterEstacion = MultiEstacionesAdapter(this, arrayEstacionPrimavera) { item ->
//             if (click1) {
//                 if (item.id == item_id) {
//                     Toast.makeText(this, "Bien", Toast.LENGTH_SHORT).show()
//                     click1 = false
//                 } else {
//                     Toast.makeText(this, "Mal", Toast.LENGTH_SHORT).show()
//                 }
//             }
//         }
//         estacionPrimavera.adapter = adapterEstacion
//
//
//        estacionOtono.layoutManager = LinearLayoutManager(this)
//        estacionInvierno.layoutManager = LinearLayoutManager(this)
//        estacionVerano.layoutManager = LinearLayoutManager(this)
//        estacionPrimavera.layoutManager = LinearLayoutManager(this)