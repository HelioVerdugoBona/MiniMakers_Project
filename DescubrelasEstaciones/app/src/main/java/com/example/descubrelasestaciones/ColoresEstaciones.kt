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

        setupRecyclerView(itemEstacionesList, itemsEstaciones,arrayEstacionesList,arrayEstaciones)
    }

    private fun setupRecyclerView(
        recyclerView1: RecyclerView,
        itemsEstaciones: MutableList<ItemEstaciones>,
        recyclerView2: RecyclerView,
        arrayEstaciones: MutableList<ItemEstaciones>
    ) {
        val adapterItem = ItemsEstacionesAdapter(this, itemsEstaciones)
        recyclerView1.layoutManager = LinearLayoutManager(this)
        recyclerView1.layoutManager = GridLayoutManager(this,4)
        recyclerView1.adapter = adapterItem


        val adapterEstacion = ItemsEstacionesAdapter(this, arrayEstaciones)
        recyclerView2.layoutManager = LinearLayoutManager(this)
        recyclerView2.layoutManager = GridLayoutManager(this,4)
        recyclerView2.adapter = adapterEstacion

        val itemEstacion = itemsEstaciones[0]
        adapterItem.setOnLongClickListener { view, i ->
            val item = itemsEstaciones[i]

            // Inicia el arrastre con una sombra personalizada
            val dragData = ClipData.newPlainText("id", item.id)
            val dragShadow = CustomDragShadowBuilder(view) // Usar la sombra personalizada
            view.startDragAndDrop(dragData, dragShadow, view, 0)
        }


        recyclerView2.setOnDragListener { _, event ->
            when (event.action) {
                DragEvent.ACTION_DROP -> {
                    // val draggedItem = event.localState as ItemEstaciones
                    // Obtener el atributo del ítem arrastrado
                    val draggedAttribute = event.clipData.getItemAt(0).text.toString()
                     println("El ID del draggedAttribute es: $draggedAttribute")

                    // Encuentra el ítem de destino (donde se soltó el arrastre)
                    val x = event.x
                    val y = event.y
                    val viewUnder = recyclerView2.findChildViewUnder(x, y)
                    val targetPosition = if (viewUnder != null) {
                        recyclerView2.getChildAdapterPosition(viewUnder)
                    } else {
                        RecyclerView.NO_POSITION
                    }
                    println("El targetPosition es: $targetPosition")


                    if (targetPosition != RecyclerView.NO_POSITION) {
                        val targetItem = arrayEstaciones[targetPosition]

                        // Compara los atributos
                        if (draggedAttribute == targetItem.id) {
                            val iterator = itemsEstaciones.iterator()
                            while (iterator.hasNext()) {
                                val item = iterator.next()
                                if (draggedAttribute == item.id) {
                                    iterator.remove() // Elimina usando el iterador
                                    adapterItem.notifyDataSetChanged()
                                    break // Salir del bucle después de eliminar
                                }
                            }
                            Log.d("DragAndDrop", "Atributos coinciden")

                        } else {
                            Log.d("DragAndDrop", "Atributos no coinciden")
                        }
                    }
                    true
                }
                DragEvent.ACTION_DRAG_ENDED -> {
                    // Restablecer la opacidad del ítem arrastrado
                    adapterEstacion.clearAlpha() // Restablecer la opacidad de todos los ítems
                    true
                }
            else -> true
            }
        }
    }

}