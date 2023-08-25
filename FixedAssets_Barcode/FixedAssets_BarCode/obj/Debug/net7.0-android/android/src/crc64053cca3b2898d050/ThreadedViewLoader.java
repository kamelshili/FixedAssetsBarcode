package crc64053cca3b2898d050;


public class ThreadedViewLoader
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.devexpress.scheduler.providers.ViewLoader
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_cancelRequestedViews:(Lcom/devexpress/scheduler/panels/ManagedLayoutViewGroup;)V:GetCancelRequestedViews_Lcom_devexpress_scheduler_panels_ManagedLayoutViewGroup_Handler:DevExpress.Android.Scheduler.Providers.IViewLoaderInvoker, DevExpress.Android.Scheduler\n" +
			"n_recycle:()V:GetRecycleHandler:DevExpress.Android.Scheduler.Providers.IViewLoaderInvoker, DevExpress.Android.Scheduler\n" +
			"n_requestNewView:(Lcom/devexpress/scheduler/providers/ViewProviderContainer;I)V:GetRequestNewView_Lcom_devexpress_scheduler_providers_ViewProviderContainer_IHandler:DevExpress.Android.Scheduler.Providers.IViewLoaderInvoker, DevExpress.Android.Scheduler\n" +
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Scheduler.Android.Internal.ThreadedViewLoader, DevExpress.Maui.Scheduler", ThreadedViewLoader.class, __md_methods);
	}


	public ThreadedViewLoader ()
	{
		super ();
		if (getClass () == ThreadedViewLoader.class) {
			mono.android.TypeManager.Activate ("DevExpress.Maui.Scheduler.Android.Internal.ThreadedViewLoader, DevExpress.Maui.Scheduler", "", this, new java.lang.Object[] {  });
		}
	}


	public void cancelRequestedViews (com.devexpress.scheduler.panels.ManagedLayoutViewGroup p0)
	{
		n_cancelRequestedViews (p0);
	}

	private native void n_cancelRequestedViews (com.devexpress.scheduler.panels.ManagedLayoutViewGroup p0);


	public void recycle ()
	{
		n_recycle ();
	}

	private native void n_recycle ();


	public void requestNewView (com.devexpress.scheduler.providers.ViewProviderContainer p0, int p1)
	{
		n_requestNewView (p0, p1);
	}

	private native void n_requestNewView (com.devexpress.scheduler.providers.ViewProviderContainer p0, int p1);

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
