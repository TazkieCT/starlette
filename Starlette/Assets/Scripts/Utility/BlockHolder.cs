using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class BlockHolder : MonoBehaviour
{
    [Header("Block Alignment Settings")]
    [SerializeField] private float blockSpacing = 1.0f;
    [SerializeField] private float blockHeight = 1.0f;
    [SerializeField] private bool centerHolderHorizontally = true;
    [SerializeField] private bool snapToGrid = false;
    [SerializeField] private float gridSize = 0.5f;

    [SerializeField] private bool showGizmos = true;
    [SerializeField] private Color gizmoColor = Color.green;

    private List<GameObject> blocks = new List<GameObject>();
    private float totalWidth = 0f;


    public GameObject AddBlock(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab is null. Cannot add block.");
            return null;
        }

        return prefab;
    }


    public void AddExistingBlock(GameObject block)
    {
        if (block == null)
        {
            Debug.LogError("Block is null. Cannot add existing block.");
            return;
        }

        TextMeshProUGUI text = block.GetComponentInChildren<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = block.GetComponent<CodeBlock>().ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found on the block.");
        }

        blocks.Add(block);
        block.transform.SetParent(transform);
        RecalculatePositions();
    }

    public void RemoveBlock(GameObject block, bool destroyBlock = true)
    {
        if (blocks.Remove(block))
        {
            if (destroyBlock)
            {
                DestroyImmediate(block);
            }
            RecalculatePositions();
        }
    }

    public void InsertExistingBlock(GameObject block, int index)
    {
        if (block == null) return;

        index = Mathf.Clamp(index, 0, blocks.Count);
        blocks.Insert(index, block);
        block.transform.SetParent(transform);
        RecalculatePositions();
    }

    public void ClearAllBlocks(bool destroyBlocks = true)
    {
        if (destroyBlocks)
        {
            foreach (GameObject block in blocks)
            {
                if (block != null)
                {
                    DestroyImmediate(block);
                }
            }
        }

        blocks.Clear();
        totalWidth = 0f;
    }

    public GameObject GetBlockAt(int index)
    {
        if (index >= 0 && index < blocks.Count)
        {
            return blocks[index];
        }
        return null;
    }

    public int GetBlockCount()
    {
        return blocks.Count;
    }

    public List<GameObject> GetAllBlocks()
    {
        return new List<GameObject>(blocks);
    }

    /// <summary>
    /// Recalculates and updates all block positions
    /// </summary>
    public void RecalculatePositions()
    {
        // Remove null references
        blocks.RemoveAll(block => block == null);
        
        if (blocks.Count == 0)
        {
            totalWidth = 0f;
            return;
        }
        
        float currentX = 0f;
        totalWidth = 0f;
        
        RectTransform panel = GetComponent<RectTransform>();
        float panelWidth = 1f;
        if (panel != null)
        {
            panelWidth = Mathf.Abs(panel.rect.width);
            if (panelWidth <= 0)
            {
                panelWidth = Mathf.Abs(panel.sizeDelta.x);
            }
        }
        
        // Calculate total width first
        for (int i = 0; i < blocks.Count; i++)
        {
            float blockWidth = GetBlockWidth(blocks[i]);
            totalWidth += blockWidth;

            if (i < blocks.Count - 1)
            {
                totalWidth += blockSpacing;
            }
        }
        
        // Calculate starting position (center the entire holder if enabled)
        float startX = centerHolderHorizontally ? 0f : -panelWidth / 2f;
        currentX = startX;
        
        // Position each block
        for (int i = 0; i < blocks.Count; i++)
        {
            GameObject block = blocks[i];
            float blockWidth = GetBlockWidth(block);
            
            // Position at the left edge of the block + half width to center it
            Vector3 newPosition = new Vector3(currentX + blockWidth / 2f, 0f, 0f);
            
            // Apply grid snapping if enabled
            if (snapToGrid)
            {
                newPosition.x = Mathf.Round(newPosition.x / gridSize) * gridSize;
                newPosition.y = Mathf.Round(newPosition.y / gridSize) * gridSize;
            }
            
            // Handle UI elements differently
            RectTransform rectTransform = block.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // For UI elements, use anchoredPosition
                rectTransform.anchoredPosition = newPosition;
                
                // Ensure proper anchoring for UI blocks
                if (rectTransform.anchorMin != new Vector2(0.5f, 0.5f) || 
                    rectTransform.anchorMax != new Vector2(0.5f, 0.5f))
                {
                    rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                }
            }
            else
            {
                // For world space objects, use localPosition
                block.transform.localPosition = newPosition;
            }
            
            // Move to next position
            currentX += blockWidth + blockSpacing;
        }
    }
    

    /// <summary>
    /// Gets the width of a block based on its renderer or collider
    /// </summary>
    /// <param name="block">The block to measure</param>
    /// <returns>The width of the block</returns>
    private float GetBlockWidth(GameObject block)
    {
        if (block == null) return 1f;

        float width = 1f;
        string debugInfo = "";
        
        // Try to get width from RectTransform first (for UI elements)
        RectTransform rectTransform = block.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            width = Mathf.Abs(rectTransform.rect.width);
            debugInfo = $"RectTransform width: {rectTransform.rect.width} (abs: {width})";
            
            // If width is 0 or negative, try to calculate from sizeDelta
            if (width <= 0)
            {
                width = Mathf.Abs(rectTransform.sizeDelta.x);
                debugInfo += $", SizeDelta.x: {rectTransform.sizeDelta.x} (abs: {width})";
            }
            
            // Still 0? Use a minimum width
            if (width <= 0)
            {
                width = 60f; // Default UI block width
                debugInfo += $", Using default: {width}";
            }
            
            // if (Application.isPlaying && showGizmos)
            // {
            //     Debug.Log($"Block '{block.name}' - {debugInfo}");
            // }
            
            return width;
        }
        
        // Try to get width from SpriteRenderer
        SpriteRenderer spriteRenderer = block.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            width = spriteRenderer.bounds.size.x;
            debugInfo = $"SpriteRenderer width: {width}";
            
            if (Application.isPlaying && showGizmos)
            {
                Debug.Log($"Block '{block.name}' - {debugInfo}");
            }
            
            return width;
        }
        
        // Try to get width from Collider2D
        Collider2D collider = block.GetComponent<Collider2D>();
        if (collider != null)
        {
            width = collider.bounds.size.x;
            debugInfo = $"Collider2D width: {width}";
            
            if (Application.isPlaying && showGizmos)
            {
                Debug.Log($"Block '{block.name}' - {debugInfo}");
            }
            
            return width;
        }
        
        // Default width
        debugInfo = $"Default width: {width}";
        if (Application.isPlaying && showGizmos)
        {
            Debug.Log($"Block '{block.name}' - {debugInfo}");
        }
        
        return width;
    }
    public float GetTotalWidth()
    {
        return totalWidth;
    }
    
    // Update positions when values change in inspector
    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            RecalculatePositions();
        }
    }
    
    // Visual debugging
    private void OnDrawGizmosSelected()
    {
        if (!showGizmos) return;
        
        Gizmos.color = gizmoColor;
        
        // Draw holder bounds
        Vector3 center = transform.position;
        Vector3 size = new Vector3(totalWidth, blockHeight, 0.1f);
        Gizmos.DrawWireCube(center, size);
        
        // Draw block positions
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i] != null)
            {
                Vector3 blockPos = transform.TransformPoint(blocks[i].transform.localPosition);
                Gizmos.DrawWireSphere(blockPos, 0.1f);
                
                // Draw block index
                #if UNITY_EDITOR
                UnityEditor.Handles.Label(blockPos + Vector3.up * 0.5f, i.ToString());
                #endif
            }
        }
    }
}