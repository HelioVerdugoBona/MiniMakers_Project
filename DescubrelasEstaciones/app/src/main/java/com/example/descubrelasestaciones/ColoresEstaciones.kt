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
import kotlin.math.log

class ColoresEstaciones: AppCompatActivity() {

    object EstacionesConstats {
        const val AVATAR = "AVATAR"
    }

    private val itemsEstaciones = mutableListOf(
        ItemEstaciones("1", "Amarillo", R.drawable.coloramarillo),
        ItemEstaciones("2", "Rosa", R.drawable.colorrosa),
        ItemEstaciones("3", "Naranja", R.drawable.colornaranja),
        ItemEstaciones("4", "Azul_Cielo", R.drawable.colorazul)
    )

    private val arrayEstaciones = mutableListOf(
        ItemEstaciones("1", "Verano", R.drawable.estiu),
        ItemEstaciones("2", "Primavera", R.drawable.primavera),
        ItemEstaciones("3", "Otoño", R.drawable.tardor),
        ItemEstaciones("4", "Invierno", R.drawable.hivern)
    )

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.colores_estaciones)

        val itemEstacionesList = findViewById<RecyclerView>(R.id.recyclerViewColores)
        val arrayEstacionesList = findViewById<RecyclerView>(R.id.recylerViewEstaciones)

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

        println("El ID del RecyclerView es: ${recyclerView.id}")

        val itemEstacion = itemsEstaciones[0]
        if (itemEstacion.nombreItem != "Verano") {
            adapter.setOnLongClickListener { view, i ->
                val item = itemsEstaciones[i]

                // Inicia el arrastre con una sombra personalizada
                val dragData = ClipData.newPlainText("id", item.id)
                val dragShadow = CustomDragShadowBuilder(view) // Usar la sombra personalizada
                view.startDragAndDrop(dragData, dragShadow, view, 0)
            }
        }

        if (itemEstacion.nombreItem == "Verano") {
            recyclerView.setOnDragListener { _, event ->
                when (event.action) {
                    DragEvent.ACTION_DROP -> {
                         val draggedItem = event.localState as ItemEstaciones
                        // Obtener el atributo del ítem arrastrado
                        //val draggedAttribute = event.clipData.getItemAt(0).text.toString()
                        // Encuentra el ítem de destino (donde se soltó el arrastre)
                        val targetPosition = recyclerView.getChildAdapterPosition(event.localState as View)

                        if (targetPosition != RecyclerView.NO_POSITION) {
                            val targetItem = arrayEstaciones[targetPosition]

                            // Compara los atributos
                            if (draggedItem.id == targetItem.id) {
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