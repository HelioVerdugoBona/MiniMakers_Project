package com.example.descubrelasestaciones;

import android.content.Context;
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.ItemTouchHelper
import androidx.recyclerview.widget.RecyclerView

class ItemsEstacionesAdapter (private val context: Context,
                              private val itemsEstaciones: MutableList<ItemEstaciones>):
    RecyclerView.Adapter<ItemsEstacionesAdapter.ItemsEstacionesViewHolder>() {

    val sourceTouchHelper = ItemTouchHelper(ItemTouchHelperCallBack(this) { fromPosition, toPosition ->
        (fromPosition, toPosition)
    })

    val destinationTouchHelper  = ItemTouchHelper(ItemTouchHelperCallBack() { fromPosition, toPosition ->
        (fromPosition, toPosition)
    })

    private val layout = R.layout.item_image

    class ItemsEstacionesViewHolder(val view: View) :
        RecyclerView.ViewHolder(view) {
        var imgItemEstaciones: ImageView

        init {
            imgItemEstaciones = view.findViewById(R.id.imageView)
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ItemsEstacionesViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(layout, parent, false)

        return ItemsEstacionesViewHolder(view)
    }

    override fun getItemCount(): Int = itemsEstaciones.size

    override fun onBindViewHolder(holder: ItemsEstacionesViewHolder, position: Int) {
        val itemEstacion = itemsEstaciones[position]

        bindItemEstaciones(holder, itemEstacion)
    }

    fun bindItemEstaciones(holder: ItemsEstacionesViewHolder, itemEstacion: ItemEstaciones) {

        holder.imgItemEstaciones.setImageResource(itemEstacion.imagen)

    }

    fun moveItem(position: Int, estaciones: MutableList<ItemEstaciones>) {
        val itemEstacion = itemsEstaciones[position]
        itemsEstaciones.removeAt(position)
        estaciones.add(itemEstacion)
        notifyItemRemoved(position)
    }

}