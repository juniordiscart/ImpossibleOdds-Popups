using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace ImpossibleOdds.Popups.UIToolkit
{
    public class PopupWindow : IPopupHandle
    {
        public event Action<IPopupHandle> onClosePopup; 
        
        private readonly VisualElement windowElement;
        private readonly TextElement headerElement;
        private readonly VisualElement contentsSiblingElement;

        private readonly IPopupDisplaySystem displaySystem;
        private readonly IPopupContents popupContents;

        private readonly List<VisualElement> contentElements = new List<VisualElement>();

        public VisualElement WindowElement => windowElement;
        
        /// <summary>
        /// The list of elements that are added as content elements for this popup window.
        /// </summary>
        private IReadOnlyList<VisualElement> AddedContentElements => contentElements;

        /// <inheritdoc />
        public IPopupContents PopupContents => popupContents;

        /// <inheritdoc />
        public IPopupDisplaySystem DisplaySystem => displaySystem;

        public PopupWindow(IPopupDisplaySystem displaySystem, IPopupContents popupContents, VisualElement windowElement, TextElement headerElement, VisualElement contentsSiblingElement)
        {
            displaySystem.ThrowIfNull(nameof(displaySystem));
            popupContents.ThrowIfNull(nameof(popupContents));
            windowElement.ThrowIfNull(nameof(windowElement));
            headerElement.ThrowIfNull(nameof(headerElement));
            contentsSiblingElement.ThrowIfNull(nameof(contentsSiblingElement));
            
            this.displaySystem = displaySystem;
            this.popupContents = popupContents;
            this.windowElement = windowElement;
            this.headerElement = headerElement;
            this.contentsSiblingElement = contentsSiblingElement;

            popupContents.onClosePopup += OnClosePopup;
        }

        public virtual void SetHeader(string header)
        {
            headerElement.text = header;
        }

        public virtual void SetContents(VisualElement contents)
        {
            contents.ThrowIfNull(nameof(contents));
            
            VisualElement parent = contentsSiblingElement.parent;
            parent.Add(contents);

            VisualElement sibling =
                contentElements.Count > 0 ?
                    contentElements.Last() :
                    contentsSiblingElement;
            
            contents.PlaceInFront(sibling);
            
            contentElements.Add(contents);
        }

        public virtual void SetContents(TemplateContainer templateContainer)
        {
            templateContainer.ThrowIfNull(nameof(templateContainer));

            while (templateContainer.childCount > 0)
            {
                VisualElement contentElement = templateContainer[0];
                templateContainer.RemoveAt(0);
                SetContents(contentElement);
            }
        }

        public virtual void SetContents(VisualTreeAsset contents)
        {
            contents.ThrowIfNull(nameof(contents));
            
            VisualElement parent = contentsSiblingElement.parent;

            contents.CloneTree(parent, out int firstElementIndex, out int elementAddedCount);
            List<VisualElement> addedElements = new List<VisualElement>(elementAddedCount);
            
            for (int i = firstElementIndex; i < firstElementIndex + elementAddedCount; ++i)
            {
                addedElements.Add(parent[i]);
            }
            
            VisualElement sibling = contentsSiblingElement;
            foreach (VisualElement addedElement in addedElements)
            {
                addedElement.PlaceInFront(sibling);
                sibling = addedElement;
            }
            
            contentElements.AddRange(addedElements);
        }

        public virtual void ClearContents()
        {
            foreach (VisualElement contentElement in contentElements)
            {
                contentsSiblingElement.parent.Remove(contentElement);
            }
            
            contentElements.Clear();
        }

        private void OnClosePopup()
        {
            onClosePopup.InvokeIfNotNull(this);
        }
        
        #region IEnumerator
        bool IEnumerator.MoveNext() => ((IPopupHandle)this).IsShowing;
        void IEnumerator.Reset() => throw new System.NotImplementedException();
        object IEnumerator.Current => this;
        #endregion
    }
}
