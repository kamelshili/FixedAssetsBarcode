package crc64053cca3b2898d050;


public class CustomViewProviderContainer
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.scheduler.providers.ViewProviderContainer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getOwnerPanel:()Lcom/devexpress/scheduler/panels/ManagedLayoutViewGroup;:GetGetOwnerPanelHandler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_setOwnerPanel:(Lcom/devexpress/scheduler/panels/ManagedLayoutViewGroup;)V:GetSetOwnerPanel_Lcom_devexpress_scheduler_panels_ManagedLayoutViewGroup_Handler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_getViewInfos:()Ljava/util/List;:GetGetViewInfosHandler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_getViewLoader:()Lcom/devexpress/scheduler/providers/ViewLoader;:GetGetViewLoaderHandler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_bindView:(Landroid/view/View;)V:GetBindView_Landroid_view_View_Handler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_createNewView:(ILandroid/content/Context;)Landroid/view/View;:GetCreateNewView_ILandroid_content_Context_Handler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_getStubColor:(I)I:GetGetStubColor_IHandler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_recycle:()V:GetRecycleHandler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_recycleView:(Landroid/view/View;)V:GetRecycleView_Landroid_view_View_Handler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"n_requestView:(I)Landroid/view/View;:GetRequestView_IHandler:DevExpress.Android.Scheduler.Providers.IViewProviderContainerInvoker, DevExpress.Android.Scheduler\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Scheduler.Android.Internal.CustomViewProviderContainer, DevExpress.Maui.Scheduler", CustomViewProviderContainer.class, __md_methods);
	}


	public CustomViewProviderContainer ()
	{
		super ();
		if (getClass () == CustomViewProviderContainer.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Scheduler.Android.Internal.CustomViewProviderContainer, DevExpress.Maui.Scheduler", "", this, new java.lang.Object[] {  });
		}
	}


	public com.devexpress.scheduler.panels.ManagedLayoutViewGroup getOwnerPanel ()
	{
		return n_getOwnerPanel ();
	}

	private native com.devexpress.scheduler.panels.ManagedLayoutViewGroup n_getOwnerPanel ();


	public void setOwnerPanel (com.devexpress.scheduler.panels.ManagedLayoutViewGroup p0)
	{
		n_setOwnerPanel (p0);
	}

	private native void n_setOwnerPanel (com.devexpress.scheduler.panels.ManagedLayoutViewGroup p0);


	public java.util.List getViewInfos ()
	{
		return n_getViewInfos ();
	}

	private native java.util.List n_getViewInfos ();


	public com.devexpress.scheduler.providers.ViewLoader getViewLoader ()
	{
		return n_getViewLoader ();
	}

	private native com.devexpress.scheduler.providers.ViewLoader n_getViewLoader ();


	public void bindView (android.view.View p0)
	{
		n_bindView (p0);
	}

	private native void n_bindView (android.view.View p0);


	public android.view.View createNewView (int p0, android.content.Context p1)
	{
		return n_createNewView (p0, p1);
	}

	private native android.view.View n_createNewView (int p0, android.content.Context p1);


	public int getStubColor (int p0)
	{
		return n_getStubColor (p0);
	}

	private native int n_getStubColor (int p0);


	public void recycle ()
	{
		n_recycle ();
	}

	private native void n_recycle ();


	public void recycleView (android.view.View p0)
	{
		n_recycleView (p0);
	}

	private native void n_recycleView (android.view.View p0);


	public android.view.View requestView (int p0)
	{
		return n_requestView (p0);
	}

	private native android.view.View n_requestView (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
