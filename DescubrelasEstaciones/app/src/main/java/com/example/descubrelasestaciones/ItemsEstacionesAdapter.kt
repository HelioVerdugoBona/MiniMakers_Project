package com.example.descubrelasestaciones

import android.annotation.SuppressLint
import android.content.ClipData
import android.content.Context
import android.view.LayoutInflater
import android.view.MotionEvent
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.recyclerview.widget.RecyclerView

class ItemsEstacionesAdapter(
    private val context: Context,
    private val itemsEstaciones: MutableList<ItemEstaciones>,
    private val isDraggable: Boolean
) : RecyclerView.Adapter<ItemsEstacionesAdapter.ItemsEstacionesViewHolder>() {
    private val layout = R.layout.item_image

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ItemsEstacionesViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(layout, parent, false)
        return ItemsEstacionesViewHolder(view)
    }

    override fun getItemCount(): Int = itemsEstaciones.size

    override fun onBindViewHolder(holder: ItemsEstacionesViewHolder, position: Int) {
        val itemEstacion = itemsEstaciones[position]
        if (isDraggable) {
            holder.bindItemDraggable(itemEstacion)
        } else {
            holder.itemView.setOnDragListener(null)
            holder.bindItemNonDraggable(itemEstacion)
        }
    }

    inner class ItemsEstacionesViewHolder(view: View) : RecyclerView.ViewHolder(view) {

        private val imgItemEstaciones = view.findViewById<ImageView>(R.id.imageView)

        @SuppressLint("ClickableViewAccessibility")
        fun bindItemDraggable(item: ItemEstaciones) {
            imgItemEstaciones.setImageResource(item.imagen)
            itemView.setOnTouchListener { view, event ->
                when (event.action) {
                    MotionEvent.ACTION_DOWN -> {
                        val dragData = ClipData.newPlainText("id", item.id)
                        val dragShadow = View.DragShadowBuilder(view)
                        itemView.startDragAndDrop(dragData, dragShadow, view, 0)
                        true
                    }
                    else -> false
                }
            }
        }

        fun bindItemNonDraggable(item: ItemEstaciones) {
            imgItemEstaciones.setImageResource(item.imagen)
        }
    }
}

